#!/bin/bash
# Setup .NET boilerplate; pass any arg to also run tests.
# For local coverage, install this:
# dotnet tool install -g dotnet-reportgenerator-globaltool
rm -rf ../../DotNet && mkdir ../../DotNet
set -euxo pipefail
cp -r ~build/Howl/Editor/Ng ../../DotNet/CLI
cd ../../DotNet
dotnet new solution --name "Main"
dotnet new console --name "CLI" --force  && rm CLI/Program.cs
dotnet sln add "CLI/CLI.csproj"
dotnet publish --runtime osx-x64
# Remove out of date Howl dir if any
sudo rm -rf /usr/local/Howl
# Copy binaries
sudo mv CLI/bin/Debug/netcoreapp3.1/osx-x64/publish /usr/local/Howl
# Remove out of date symlink if any
sudo rm -f /usr/local/bin/howl
# Create new Symlink
sudo ln -s /usr/local/Howl/CLI /usr/local/bin/howl
howl
