#!/bin/bash
if [ "$#" -ne 1 ]; then
    echo "USAGE: $0 VersionToBumpTo"
    exit 1;
fi
git pull
sed -i '' "s/<Version>.*<\/Version>/<Version>$1<\/Version>/" Xamarin.Amplitude.iOS/Xamarin.Amplitude.iOS.csproj
git add Xamarin.Amplitude.iOS/Xamarin.Amplitude.iOS.csproj
git commit -m "bumped version to $1"
git push
git pull
git tag release-bindings-v$1
git push origin release-bindings-v$1
