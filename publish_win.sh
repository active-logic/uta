#!/bin/bash
# Publish Howl; suitable for git-bash on Windows
# for sudo on gitbash
# curl -s https://raw.githubusercontent.com/imachug/win-sudo/master/install.sh | sh
# or visit https://github.com/imachug/win-sudo
# usage:
# sudo publish_win.sh
rm -rf ../../DotNet && mkdir ../../DotNet
set -euo pipefail
cp -r ~build/Howl/Editor/Ng ../../DotNet/CLI
cd ../../DotNet
dotnet new solution --name "Main"
dotnet new console --name "CLI" --force && rm CLI/Program.cs
dotnet sln add "CLI/CLI.csproj"
dotnet publish --runtime win-x64
# Remove out of date Howl dir if any
rm -rf /usr/lib/howl
# Copy binaries
mv CLI/bin/Debug/netcoreapp3.1/win-x64/publish /usr/lib/howl
# Rename executable
mv /usr/lib/howl/CLI.exe /usr/lib/howl/howl.exe
# Add to bashrc
grep -qxF 'export PATH="/usr/lib/howl/:$PATH"' ~/.bashrc || \
  echo 'export PATH="/usr/lib/howl/:$PATH"' >> ~/.bashrc
# Would need a subshell or such to run before rebooting
echo "Restart your shell and type 'howl' to confirm the installation"
