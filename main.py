import os
import sys
import json
import argparse
from modules.trainModel import TrainModel
from modules.predictDisease import predictDisease
import matplotlib.pyplot as plt
from modules.configLoader import loadConfig  # using loadConfig

os.environ["TF_CPP_MIN_LOG_LEVEL"] = "3"  # suppress TF logs
RESULTS_DIR = "results"
os.makedirs(RESULTS_DIR, exist_ok=True)

# ==== Logging functions ====
def saveTrainingLogs(history, history_finetune):
    all_history = {
        "phase1": history.history,
        "phase2": history_finetune.history
    }
    with open(os.path.join(RESULTS_DIR, "training_history.json"), "w") as f:
        json.dump(all_history, f, indent=4)

    plt.figure()
    plt.plot(history.history["accuracy"] + history_finetune.history["accuracy"], label="Train Acc")
    plt.plot(history.history["val_accuracy"] + history_finetune.history["val_accuracy"], label="Val Acc")
    plt.xlabel("Epoch")
    plt.ylabel("Accuracy")
    plt.legend()
    plt.title("Training & Validation Accuracy")
    plt.savefig(os.path.join(RESULTS_DIR, "training_plot.png"))
    plt.close()

def savePredictionLog(result):
    log_file = os.path.join(RESULTS_DIR, "predictions.json")
    logs = []
    if os.path.exists(log_file):
        with open(log_file, "r") as f:
            logs = json.load(f)
    logs.append(result)
    with open(log_file, "w") as f:
        json.dump(logs, f, indent=4)

# ==== CLI (for C# integration) ====
def cli():
    parser = argparse.ArgumentParser(description="Beans Leaf Disease Detection CLI")
    parser.add_argument("--train", action="store_true", help="Train the model")
    parser.add_argument("--predict", type=str, help="Path to image file for prediction")
    parser.add_argument("--model", type=str, help="Model name (e.g., mobilenetv3, vgg19)")
    args = parser.parse_args()

    if args.train:
        print("Starting training...")
        history, history_finetune = TrainModel()
        saveTrainingLogs(history, history_finetune)
        print(json.dumps({"status": "success", "message": "Training completed"}))
        sys.exit(0)

    if args.predict:
        try:
            config = loadConfig()  # read config
            if args.model:
                config["USE_MODEL"] = args.model
                config["MODEL_PATH"] = f"models/{args.model}_beans.keras"

            result = predictDisease(args.predict)
            savePredictionLog(result)
            print(json.dumps(result))  # JSON for C#
            sys.exit(0)
        except Exception as e:
            print(json.dumps({"error": True, "message": str(e)}))
            sys.exit(2)

    return False  # fallback to interactive

# ==== Fallback Interactive Menu ====
if __name__ == "__main__":
    if not cli():
        while True:
            print("#######################################################################")
            print("=== Beans Leaf Disease Detection System ===")
            print("1. Train the model")
            print("2. Predict a single image")
            print("3. Exit")
            print("#######################################################################")
            choice = input("Enter your choice (1 or 2): ").strip()

            if choice == "1":
                print("Starting training...")
                history, history_finetune = TrainModel()
                saveTrainingLogs(history, history_finetune)
                print(f"Training completed. Logs saved in {RESULTS_DIR}/")
            elif choice == "2":
                img_path = input("Enter path to image: ").strip()
                model_name = input("Enter model name (mobilenetv3 / vgg19, leave blank to use config): ").strip()
                
                config = loadConfig()  # read config
                if model_name:
                    config["USE_MODEL"] = model_name
                    config["MODEL_PATH"] = f"models/{model_name}_beans.keras"

                if not os.path.exists(img_path):
                    print("Invalid image path. Exiting.")
                    continue

                print(f"🔎 Predicting disease for: {img_path}")
                result = predictDisease(img_path)
                savePredictionLog(result)
                print(f"Prediction: {result['prediction']} ({result['confidence']:.2f})")
                print(f"Info:")
                print(f"\nName: {result['name']}")
                print(f"Cause: {result['cause']}")
                print(f"Symptoms: {result['symptoms']}")
                print(f"Cure Steps:\n{result['cure_steps']}")
                print(f"Plant Survival: {result['plant_survival']}")
                print(f"Recovery Time: {result['recovery_time']}")
                print(f"Extra Tips:\n{result['extra_tips']}")
                print(f"Log saved to {RESULTS_DIR}/predictions.json")
            elif choice == "3":
                print("Exiting!")
                break
            else:
                print("Invalid choice. Please run again and select 1 or 2.")
