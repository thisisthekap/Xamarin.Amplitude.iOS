#!/bin/bash

cd processing

make

cp libAmplitude.a ../../Xamarin.Amplitude.iOS/nativelib/libAmplitude.a

# cleanup
cd ..
rm -rf processing
