$publishDir = "publish"
$appDir = "sharedlibrary"
$projectPath = "sharedlibrary\sharedlibrary.csproj"
$testfile = "sharedlibrary\sharedlibrary.Tests\bin\Debug\K9.sharedlibrary.Tests.dll"
	
function ProcessErrors(){
  if($? -eq $false)
  {
    throw "The previous command failed (see above)";
  }
}

function _DeleteFile($fileName) {
  If (Test-Path $fileName) {
    Write-Host "Deleting '$fileName'"
    Remove-Item $fileName
  } else {
    "'$fileName' not found. Nothing deleted"
  }
}

function _CreateDirectory($dir) {
  If (-Not (Test-Path $dir)) {
    New-Item -ItemType Directory -Path $dir
  }
}

function _NugetRestore() {
  echo "Running nuget restore"

  pushd $appDir
  ProcessErrors
  
  nuget restore
  ProcessErrors
  popd
}

function _Test() {
  echo "Running tests"
  
  pushd $appDir  
  ProcessErrors
  
  Write-Host "packages\xunit.runner.console.2.2.0\tools\xunit.console.exe " + $testfile
  ProcessErrors
  
  popd
}

function Main {
  Try {
	_Test	
  }
  Catch {
    Write-Error $_.Exception
    exit 1
  }
}

Main