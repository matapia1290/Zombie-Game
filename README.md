

This is a zombie game to practice unity 3D.


import random

def hangman():
    words = ["python", "java", "kotlin", "javascript"]
    word = random.choice(words)
    guessed_word = ["_"] * len(word)
    attempts = 6

    while attempts > 0 and "_" in guessed_word:
        print(" ".join(guessed_word))
        guess = input("Guess a letter: ").lower()

        if guess in word:
            for i, letter in enumerate(word):
                if letter == guess:
                    guessed_word[i] = guess
        else:
            attempts -= 1
            print(f"Incorrect! You have {attempts} attempts left.")

    if "_" not in guessed_word:
        print(f"Congratulations! You guessed the word: {''.join(guessed_word)}")
    else:
        print(f"You lost! The word was: {word}")

hangman()
