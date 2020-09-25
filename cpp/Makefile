LIB:=$(wildcard ./lib/*.cpp)
OBJ:=$(LIB:./lib/%.cpp=./obj/%.o)
EXE:=main

$(EXE): main.cpp func.h $(OBJ)
	g++ -o $@ -std=c++11 $^

obj/%.o: lib/%.cpp lib/%.h
	mkdir -p ./obj
	g++ -c $< -o $@ -std=c++11

.PHONY: clean
clean:
	rm -r $(EXE) obj/
