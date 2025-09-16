from tensorflow.keras import layers, models
from tensorflow.keras.applications import MobileNetV3Large, VGG19
from tensorflow.keras.applications.mobilenet_v3 import preprocess_input as mobilenet_preprocess
from tensorflow.keras.applications.vgg19 import preprocess_input as vgg_preprocess
from modules.configLoader import loadConfig

cfg = loadConfig()
IMG_SIZE = tuple(cfg["IMG_SIZE"])
USE_MODEL = cfg["USE_MODEL"]

def getBaseModel():
    if USE_MODEL.lower() == "mobilenetv3":
        base_model = MobileNetV3Large(weights="imagenet", include_top=False, input_shape=IMG_SIZE + (3,))
        preprocess_func = mobilenet_preprocess
    elif USE_MODEL.lower() == "vgg19":
        base_model = VGG19(weights="imagenet", include_top=False, input_shape=IMG_SIZE + (3,))
        preprocess_func = vgg_preprocess
    else:
        raise ValueError("Invalid model choice! Choose 'mobilenetv3' or 'vgg19'.")
    return base_model, preprocess_func

def buildModel(base_model):
    base_model.trainable = False
    model = models.Sequential([
        base_model,
        layers.GlobalAveragePooling2D(),
        layers.Dense(128, activation='relu'),
        layers.Dropout(0.3),
        layers.Dense(3, activation='softmax')
    ])
    model.compile(optimizer='adam', loss='categorical_crossentropy', metrics=['accuracy'])
    return model
