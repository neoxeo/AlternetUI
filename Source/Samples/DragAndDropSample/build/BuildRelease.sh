#!/bin/bash
pushd ../../../Alternet.UI.Pal/build
./release.sh
popd
pushd ..
dotnet build DragAndDropSample.csproj -c Release
popd