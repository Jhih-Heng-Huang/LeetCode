CS=/mnt/c/Windows/Microsoft.NET/Framework64/v4.0.30319/csc.exe
DLL_FILE=Lib.dll
LIB_DIR=Lib
MAIN=main


$(MAIN):
	$(CS) -target:library -out:$(LIB_DIR)\\$(DLL_FILE)  $(LIB_DIR)\\*.cs
	$(CS) -lib:$(LIB_DIR) -reference:$(DLL_FILE) $(MAIN).cs


clean:
	rm $(LIB_DIR)/$(DLL_FILE)
	rm $(MAIN).exe