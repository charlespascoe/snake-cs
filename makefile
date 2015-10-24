OUT=snake.exe

all:
	mkdir -p bin/
	mcs -out:bin/$(OUT) -pkg:dotnet -recurse:'src/*.cs'

run: all
	mono bin/$(OUT)
