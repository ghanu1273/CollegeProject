import os
import json

def loadConfig():
    baseDir = os.path.dirname(os.path.dirname(__file__))
    configPath = os.path.join(os.path.dirname(__file__), "config.json")

    with open(configPath, "r") as f:
        cfg = json.load(f)
        cfg["MODEL_PATH"] = cfg["MODEL_PATH"].format(USE_MODEL=cfg["USE_MODEL"])
    for key in ["MODEL_PATH", "BEANS_DATASET_PATH", "CLASSLABELS_PATH"]:
        if key in cfg:
            cfg[key] = os.path.join(baseDir, cfg[key])

    return cfg
