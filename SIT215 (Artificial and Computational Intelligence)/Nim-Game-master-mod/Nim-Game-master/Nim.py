# Modified verson of Game of Nim
#
# References:
# Liu, T & Bryan, C 2016, tkl5/Nim-Game: Python code for the mathematical Nim puzzle game, featuring two players and computer hints, Retrieved 13th September 2020,
# <https://github.com/tkl5/Nim-Game>

import random

# the main function


def main():
    # Define an empty list to append rocks to, define random integers, call functions
    list_main = []
    # The number of piles will be random in between 2 and 5
    piles = random.randint(2, 5)
    rocks = (2*piles)+1  # The number of rocks will be 2*N+1
    name1, name2 = get_players()  # The game consists of 2 players

    player = name1  # Set current player to 1 (for switching later)

    get_board(list_main, piles, rocks, player)  # Set initial board

    play_again(list_main, piles, rocks, name1, name2, player)

# get_player() function:
# Returns : the player names as strings entered by the user


def get_players():
    return input("Enter player 1 name: "), input("Enter player 2 name: ")

# get_board() function
# Parameters:
#   -> empty list_main
#   -> random pile as integers
#   -> rocks as integer
#   -> current player as string
# End : modifies list_main with random piles and stones, prints initial starting board


def get_board(list_main, piles, rocks, player):

    # Get initial board
    print("Let's look at the board now.")
    print("-" * 25)
    for i in range(0, piles):
        rocks = random.randint(1, 8)
        print('Pile {}: {}'.format(i + 1, 'O' * rocks))
        list_main.append(rocks)
    print("-" * 25)

    # Call nim function to display computer hints
    nim_sum(list_main, piles)

# get_valid_input() function:
# Parameters :
#   -> modified list_main
#   -> random integer for piles
#   -> current player as string
# End : updates game board for following turns
# Returns : a string when input is invalid,


def get_valid_input(list_main, piles, player):

    # Begin loop that tests for valid input - if valid, break loop - if not, keep asking
    while True:
        stones = input('{}, how many stones to remove? '.format(player))
        piles = input('Pick a pile to remove from: ')

        # If all condiitons for input are CORRECT, break out of loop
        if (stones and piles) and (stones.isdigit()) and (piles.isdigit()):
            if (int(stones) > 0) and (int(piles) <= len(list_main)) and (int(piles) > 0):
                if (int(stones) <= list_main[int(piles) - 1]):
                    if (int(stones) != 0) and (int(piles) != 0):
                        break

        # If not, display this statement
        print("Hmmm. You entered an invalid value. Try again, {}.".format(player))

    # Update state
    list_main[int(piles) - 1] -= int(stones)

    # Keep playing game
    continue_game(list_main, piles, player)

# continue_game() function:
# Parameters :
#   -> modified list_main
#   -> random integer for piles
#   -> current player as string
# End : prints out updated game board after moves have been made, displays computer hint


def continue_game(list_main, piles, player):
    print("Let's look at the board now.")
    print("-" * 25)
    for i in range(0, piles):
        print("Pile {}: {}".format(i + 1, 'O' * list_main[i]))

    print("-" * 25)

    # In the case when game is over, do not display computer hint for empty board
    if list_main != [0] * len(list_main):
        nim_sum(list_main, piles)

    # print(list_main)
# play_again() function:
# Parameters :
#   -> modified list_main
#   -> random integer for piles
#   -> names of players
#   -> current palyer as string
# End : prints winner of game, asks if players want to play game again, determine current player


def play_again(list_main, piles, rocks, name1, name2, player):

    # Begin loop to initiate player switching
    while True:
        get_valid_input(list_main, piles, player)

        # To determine winner, check if list_main contains all 0's on that player's turn
        if list_main == [0] * len(list_main):
            print("{} is the winner of this round!".format(player))
            user = input(
                "Do you want to play again? Enter y for yes, anything for no: ")

            if user.lower() == 'y':
                # reset all conditions, start the game again
                list_main = []
                piles = random.randint(2, 5)
                name1, name2 = get_players()
                player = name1
                get_board(list_main, piles, rocks, player)
                get_valid_input(list_main, piles, player)

            else:
                break

        # switch players 2->1, 1->2
        if player == name1:
            player = name2

        else:
            player = name1
# nim_sum() function:
# Parameters :
#   -> modified list_main
#   -> random integer for piles
# End : calculates nim sum and prints the computer hint for optimal moves


def nim_sum(list_main, piles):
    nim = 0

    # Calculate nim sum for all elements in the list_main
    for i in list_main:
        nim = nim ^ i

    print("Hint: nim sum is {}.".format(nim))

    # Determine how many rocks to remove from which pile
    stones_to_remove = max(list_main) - nim
    stones_to_remove = abs(stones_to_remove)

    # Logic for certain configurations on determining how many stones to remove from which pile
    # "list_main.index(max(list_main))+ 1 )" determines the index in list_main at which the biggest
    # pile of stones exists.
    if (nim > 0) and (len(list_main) > 2) and (nim != max(list_main)) and (nim != 1):
        print("Pick {} stones from pile {}".format(
            stones_to_remove, list_main.index(max(list_main)) + 1))

    if (nim > 0) and (len(list_main) > 2) and (nim == max(list_main)) and (nim != 1):
        print("Pick {} stones from pile {}.".format(
            nim, list_main.index(max(list_main)) + 1))

    if nim > 0 and len(list_main) <= 2 and (stones_to_remove != 0):
        print("Pick {} stones from pile {}".format(
            stones_to_remove, list_main.index(max(list_main)) + 1))

    if nim > 0 and len(list_main) <= 2 and (stones_to_remove == 0):
        print("Pick {} stones from pile {}".format(
            nim, list_main.index(max(list_main)) + 1))

    elif (nim == 1) and (len(list_main) <= 2):
        print("Pick {} stones from pile {}".format(
            nim, list_main.index(max(list_main)) + 1))

    if (nim == 1) and (nim == max(list_main)) and (nim != 0) and (len(list_main) > 2):
        print("Pick {} stones from pile {}".format(
            nim, list_main.index(max(list_main)) + 1))

    if nim == 0:
        print("Pick all stones from pile {}.".format(
            list_main.index(max(list_main)) + 1))


# Call the main function
main()
