OBJ=obj/dynamic_programming.o
EXE=main

$(EXE): main.cpp func.h $(OBJ)
	g++ -o $@ -std=c++11 $^

obj/%.o: lib/%.cpp lib/%.h
	g++ -c $< -o $@ -std=c++11

.PHONY: clean
clean:
	rm -r $(EXE) $(OBJ)
