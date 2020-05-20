KOTLIN=kotlinc
JAVA=java
MAIN=main
LIBS=Lib/*.kt

$(MAIN):
	$(KOTLIN) -include-runtime -d $(MAIN).jar $(MAIN).kt $(LIBS)

run:
	$(JAVA) -jar $(MAIN).jar

clean:
	rm *.jar