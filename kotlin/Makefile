KOTLIN=kotlinc
JAVA=java
MAIN=main

$(MAIN):
	$(KOTLIN) $(MAIN).kt -include-runtime -d $(MAIN).jar

run:
	$(JAVA) -jar $(MAIN).jar

clean:
	rm *.jar