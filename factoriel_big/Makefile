SRCS = Program.cs
CC = mcs
FREF = -r
REF = System.Numerics.dll
NAME = factoriel_big.exe

.PHONY: all clean re

all: $(NAME)

$(NAME):
	$(CC) $(FREF):$(REF) -out:$@ $(SRCS)

clean:
	rm -fv $(NAME)

re: clean all
