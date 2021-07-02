for /d /r %%i in (bin*) do (
    @rmdir /s /q "%%i"
    echo Removed "%%i"
    )
    for /d /r %%i in (obj*) do (
    @rmdir /s /q "%%i"
    echo Removed "%%i"
    )