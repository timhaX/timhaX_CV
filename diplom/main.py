import os
import numpy as np
import matplotlib.pyplot as plt
from tensorflow import keras
from tensorflow.keras.layers import *
from tensorflow.keras.losses import *
from tensorflow.keras.models import *
from tensorflow.keras.metrics import *
from tensorflow.keras.optimizers import *
from tensorflow.keras.applications.vgg16 import VGG16
from tensorflow.keras.preprocessing.image import load_img
from sklearn.metrics import classification_report
from sklearn.utils import shuffle
from PIL import Image, ImageEnhance
from tqdm import tqdm
import random

x_train_paths = []
y_train_paths = []
x_val_paths = []
y_val_paths = []
all_paths = []
all_labels = []
data_dir = 'F:/pythonProject2/dataset/'
for label in os.listdir(data_dir):
    for image in os.listdir(data_dir+label):
        all_paths.append(data_dir+label+'/'+image)
        all_labels.append(label)
all_paths, all_labels = shuffle(all_paths, all_labels)

x_train_paths = all_paths[:5000]
y_train = all_labels[:5000]
x_val_paths = all_paths[5000:]
y_val = all_labels[5000:]

def augment_image(image):
    image = Image.fromarray(np.uint8(image))
    image = ImageEnhance.Brightness(image).enhance(random.uniform(0.6,1.4))
    image = ImageEnhance.Contrast(image).enhance(random.uniform(0.6,1.4))
    image = np.array(image)/255.0
    return image

def open_images(paths):
    images = []
    for path in paths:
        image = load_img(path, target_size=(224,224))
        image = augment_image(image)
        images.append(image)
    return np.array(images)

num_images = 9
images = open_images(x_train_paths[:num_images])
fig = plt.figure(figsize=(16, round(num_images/4)*4))
for x in range(1, num_images):
    fig.add_subplot(int(num_images/4), 4, x)
    plt.axis('off')
    plt.title(y_train[x])
    plt.imshow(images[x])
plt.show()

unique_labels = os.listdir('F:/pythonProject2/dataset/')
def encode_label(labels):
    encoded = []
    for x in labels:
        encoded.append(unique_labels.index(x))
    return np.array(encoded)

def decode_label(labels):
    decoded = []
    for x in labels:
        decoded.append(unique_labels[x])
    return np.array(decoded)

def data_gen(paths, labels, batch_size=12):
    if len(paths) != len(labels):
        raise Exception('The length of paths is ', len(paths), ' but the length of labels is ', len(labels))

    for x in range(0, len(paths), batch_size):
        batch_paths = paths[x:x + batch_size]
        batch_images = open_images(batch_paths)
        batch_labels = labels[x:x + batch_size]
        batch_labels = encode_label(batch_labels)
        yield batch_images, batch_labels

vgg16 = VGG16(input_shape=(224,224,3), include_top=False, weights='imagenet')
# Set all layers to non-trainable
for layer in vgg16.layers:
    layer.trainable = False

model = Sequential()
model.add(Input(shape=(224,224,3)))
model.add(vgg16)
model.add(Flatten())
model.add(Dropout(0.3))
model.add(Dense(768, activation='relu'))
model.add(Dropout(0.25))
model.add(Dense(256, activation='relu'))
model.add(Dropout(0.25))
model.add(Dense(len(unique_labels), activation='softmax'))

model.summary()
model.compile(optimizer=Adam(learning_rate=0.0001),
              loss='sparse_categorical_crossentropy',
              metrics=['accuracy'])
batch_size=12
steps = int(len(x_train_paths)/batch_size)
epochs=12
for _ in range(epochs):
    model.fit(data_gen(x_train_paths, y_train, batch_size=batch_size), epochs=1, steps_per_epoch=steps)

batch_size=12
steps = int(len(x_val_paths)/batch_size)
y_pred = []
y_true = []
for x,y in tqdm(data_gen(x_val_paths, y_val, batch_size=batch_size), total=steps):
    pred = model.predict(x)
    pred = np.argmax(pred, axis=-1)
    for i in pred:
        y_pred.append(i)
    for i in y:
        y_true.append(i)
print(classification_report(y_true, y_pred))
