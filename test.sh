#!/bin/bash
# Setup .NET boilerplate; pass any arg to also run tests.
# For local coverage, install this:
# dotnet tool install -g dotnet-reportgenerator-globaltool
rm -rf ../../DotNet && mkdir ../../DotNet
set -euo pipefail
cp -r ~build/Howl/Editor/Ng ../../DotNet/Lib
cp -r ~build/Howl/Tests/Ng ../../DotNet/Tests

# COPY TEST DATA
# .TestData/ is mocking the Assets/ directory structure to help with
# testing; first, copy the mock structure.
mkdir -p ../../DotNet/Tests/bin/Debug/netcoreapp3.1/
cp -r .TestData ../../DotNet/Tests/bin/Debug/netcoreapp3.1/Assets
# Next, adding Tests/Data
mkdir -p ../../DotNet/Tests/bin/Debug/netcoreapp3.1/Assets/Howl/Tests
cp -r Tests/Data ../../DotNet/Tests/bin/Debug/netcoreapp3.1/Assets/Howl/Tests/
# END

cd ../../DotNet
dotnet new solution --name "Main"
dotnet new classlib --name "Lib"   --force && rm Lib/Class1.cs
dotnet new nunit    --name "Tests" --force && rm Tests/UnitTest1.cs
dotnet add "Tests/Tests.csproj" reference "Lib/Lib.csproj"
dotnet add "Tests/Tests.csproj" package coverlet.msbuild
dotnet sln add "Lib/Lib.csproj" "Tests/Tests.csproj"
if [ "$#" -eq  "0" ]
  then
    exit 0
  else
    dotnet test -c Debug -p:CollectCoverage=true \
                          -p:CoverletOutputFormat=opencover
    reportgenerator -reports:Tests/coverage.opencover.xml \
                     -targetdir:CoverageReport
    open CoverageReport/index.htm
fi
