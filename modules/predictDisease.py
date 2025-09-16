import os
import matplotlib.pyplot as plt
import numpy as np
import json
import tensorflow as tf
from tensorflow.keras.preprocessing import image
from modules.configLoader import loadConfig
from modules.trainModel import TrainModel
import datetime
import sys

#For c#
if sys.stdout is None:
    sys.stdout = open(os.devnull, "w")
if sys.stderr is None:
    sys.stderr = open(os.devnull, "w")


cfg = loadConfig()
MODEL_PATH = cfg["MODEL_PATH"]
IMG_SIZE = tuple(cfg["IMG_SIZE"])
DISEASE_INFO = cfg["DISEASE_INFO"]
CLASSLABEL_PATH = cfg["CLASSLABELS_PATH"]
RESULTS_DIR = "results"
os.makedirs(RESULTS_DIR, exist_ok=True)

def saveTrainingLogs(history, history_finetune):
    all_history = {
        "phase1": history.history,
        "phase2": history_finetune.history
    }

    # Save JSON
    with open(os.path.join(RESULTS_DIR, "training_history.json"), "w") as f:
        json.dump(all_history, f, indent=4)

    # Save accuracy plot
    plt.figure()
    plt.plot(history.history["accuracy"] + history_finetune.history["accuracy"], label="Train Acc")
    plt.plot(history.history["val_accuracy"] + history_finetune.history["val_accuracy"], label="Val Acc")
    plt.xlabel("Epoch")
    plt.ylabel("Accuracy")
    plt.legend()
    plt.title("Training & Validation Accuracy")
    plt.savefig(os.path.join(RESULTS_DIR, "training_plot.png"))
    plt.close()

def loadClassLabels():
    possible_paths = [
        "class_labels.npy",
        CLASSLABEL_PATH,
        os.path.join("results", "class_labels.npy"),
        os.path.join("models", "class_labels.npy")
    ]
    for path in possible_paths:
        if os.path.exists(path):
            return np.load(path, allow_pickle=True).item()
    raise FileNotFoundError("class_labels.npy not found! Make sure to run training first.")



def predictDisease(img_path):
    class_labels = loadClassLabels()
    
    if not os.path.exists(MODEL_PATH):
        print(f"{MODEL_PATH} does not exist.")
        print("Starting training...")
        history, history_finetune = TrainModel()
        saveTrainingLogs(history, history_finetune)
        print(f"Training completed. Logs saved in {RESULTS_DIR}/")

    model = tf.keras.models.load_model(MODEL_PATH)
    
    img_path = os.path.normpath(img_path).replace("\\", "/")
    if not os.path.exists(img_path):
        raise FileNotFoundError(f"Image not found at {img_path}")

    img = image.load_img(img_path, target_size=IMG_SIZE)
    img_array = image.img_to_array(img)
    img_array = np.expand_dims(img_array, axis=0)

    # Preprocess according to selected model
    if cfg["USE_MODEL"].lower() == "mobilenetv3":
        from tensorflow.keras.applications.mobilenet_v3 import preprocess_input
    else:
        from tensorflow.keras.applications.vgg19 import preprocess_input

    img_array = preprocess_input(img_array)

    # Predict
    preds = model.predict(img_array)
    pred_idx = int(np.argmax(preds))
    pred_class = class_labels[pred_idx]
    confidence = float(preds[0][pred_idx])

    # Build detailed info string
    #disease_info = DISEASE_INFO.get(pred_class, {})
    #if disease_info:
    #    info_str = f"Name: {disease_info.get('name','')}\n"
     #   info_str += f"Cause: {disease_info.get('cause','')}\n"
      #  info_str += f"Symptoms: {disease_info.get('symptoms','')}\n"
       # info_str += "Cure Steps:\n"
       # for i, step in enumerate(disease_info.get("cure", []), 1):
        #    info_str += f"  {i}. {step}\n"
    #else:
     #   info_str = "No info available."
    info = DISEASE_INFO[pred_class]

    # Convert Cure Steps list to string for display
    #cure_steps = "\n".join(f"{i+1}. {step}" for i, step in enumerate(info["cure"]))
    cure_steps = "\n".join(f"{i+1}. {step}" for i, step in enumerate(info["cure"]))
    extra_tips = "\n".join(f"{i+1}. {tip}" for i, tip in enumerate(info["extra_tips"]))

    print(cure_steps)
    result = {
        "image": img_path,
        "prediction": pred_class,
        "confidence": confidence,
        "name": info['name'],
        "cause": info['cause'],
        "symptoms": info['symptoms'],
        "cure_steps": cure_steps,
        "plant_survival": info['plant_survival'],
        "recovery_time": info['recovery_time'],
        "extra_tips": extra_tips,
        "timestamp": datetime.datetime.now().isoformat()
    }

    return result

