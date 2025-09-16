from tensorflow.keras.callbacks import EarlyStopping
from tensorflow.keras.optimizers import Adam
from modules.configLoader import loadConfig
from modules.buildModel import getBaseModel, buildModel
from modules.dataLoader import getData

cfg = loadConfig()

def TrainModel():
    base_model, preprocess_func = getBaseModel()
    model = buildModel(base_model)
    train_gen, val_gen = getData(preprocess_func)

    early_stop = EarlyStopping(monitor='val_loss', patience=5, restore_best_weights=True)

    # Train Phase 
    history = model.fit(train_gen, validation_data=val_gen,
                        epochs=cfg["EPOCHS"], callbacks=[early_stop])

    # Fine-tune Phase
    base_model.trainable = True
    for layer in base_model.layers[:-30]:
        layer.trainable = False

    model.compile(optimizer=Adam(learning_rate=1e-5),
                  loss='categorical_crossentropy',
                  metrics=['accuracy'])

    history_finetune = model.fit(train_gen, validation_data=val_gen,
                                 epochs=cfg["EPOCHS"] + cfg["FINE_TUNE_EPOCHS"],
                                 initial_epoch=len(history.epoch),
                                 callbacks=[early_stop])
    model.save(cfg["MODEL_PATH"])
    print(f"Model saved at {cfg['MODEL_PATH']}")
    return history, history_finetune
