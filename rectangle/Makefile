SRCS = Program.cs
CC = mcs
NAME = rectangle.exe

.PHONY: all clean re

all: $(NAME)

$(NAME):
	$(CC) -out:$@ $(SRCS)

clean:
	rm -fv $(NAME)

re: clean all
