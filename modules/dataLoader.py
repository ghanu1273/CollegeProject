import os
import numpy as np
from tensorflow.keras.preprocessing.image import ImageDataGenerator
from modules.configLoader import loadConfig

cfg = loadConfig()
BEANS_DATASET_PATH = cfg["BEANS_DATASET_PATH"]
IMG_SIZE = tuple(cfg["IMG_SIZE"])
BATCH_SIZE = cfg["BATCH_SIZE"]

def getData(preprocess_func):
    train_datagen = ImageDataGenerator(
        preprocessing_function=preprocess_func,
        rotation_range=20,
        zoom_range=0.2,
        width_shift_range=0.2,
        height_shift_range=0.2,
        horizontal_flip=True
    )
    val_datagen = ImageDataGenerator(preprocessing_function=preprocess_func)

    train_path = os.path.join(BEANS_DATASET_PATH, "train")
    val_path = os.path.join(BEANS_DATASET_PATH, "validation")

    train_gen = train_datagen.flow_from_directory(
        train_path, target_size=IMG_SIZE, batch_size=BATCH_SIZE, class_mode='categorical'
    )
    val_gen = val_datagen.flow_from_directory(
        val_path, target_size=IMG_SIZE, batch_size=BATCH_SIZE, class_mode='categorical'
    )
    class_labels = {v: k for k, v in train_gen.class_indices.items()}
    np.save("class_labels.npy", class_labels)

    return train_gen, val_gen
