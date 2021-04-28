# Xamarin.Amplitude.iOS

Xamarin.iOS Bindings for Amplitude ([Website](https://amplitude.com), [Setup Instructions](https://developers.amplitude.com/docs/ios))

## NuGet Feed

TODO

## Versioning Scheme

The versioning scheme of `Xamarin.Amplitude.iOS` is derived from the versioning of `amplitude/Amplitude-iOS`.

### Example:

| amplitude/Amplitude-iOS | Xamarin.Amplitude.iOS | Note |
|:--|:--|:--|
| 3.4.1 | 3.4.1.1 | First version of bindings for 3.4.1 |
| 3.4.1 | 3.4.1.17 | Bindings for 3.4.1 containing fixes |

## SSL Pinning not supported

This Xamarin.iOS binding does NOT support certificate pinning which would be enabled by setting `AMPLITUDE_SSL_PINNING=1`.

This project does not include the `ComodoRsaDomainValidationCA.der` file in the native library.

## Troubleshooting

### unrecognized selector sent to instance

If initialization crashes and you get errors like `[RCPurchases configureSubscriberAttributesManager]: unrecognized selector sent to instance`, please adapt your project configuration:

Add `-gcc_flags "-ObjC"` to the `MtouchExtraArgs` XML element of your project file. If you want to do the config change using the UI Editor, the change is given below:

![troubleshooting-unrecognized-selector](readme-images/troubleshooting-unrecognized-selector.png)

## How to bind new version

This section explains how to create resp. adapt the bindings to bind to a newer version of Amplitude for iOS.

### Build static library

1. `cd nativelib`
2. Set the desired version of Amplitude for iOS in `prepare-library-build.sh`
3. Execute `./prepare-library-build.sh`
4. Right click "Amplitude" to add files:
	* ![howto-1](readme-images/howto-1.png)
5. Select everything in the "Amplitude" folder, and make sure that the settings are configured as described:
	* ![howto-2](readme-images/howto-2.png)
6. Press "Add"
7. Close XCode
8. Execute `./finish-library-build.sh`

After these steps, a new static library was built and moved to `Xamarin.Amplitude.iOS/nativelib/libPurchases.a`. This file is referenced as `NativeReference` in `Xamarin.Amplitude.iOS.csproj`.

### Create C# Bindings using Objective Sharpie

This section describes how to create `ApiBindings.cs`.

1. `cd sharpie`
2. Execute `./generate-bindings.sh`
3. Copy `ApiBindings.cs` to `../Xamarin.Amplitude.iOS`
