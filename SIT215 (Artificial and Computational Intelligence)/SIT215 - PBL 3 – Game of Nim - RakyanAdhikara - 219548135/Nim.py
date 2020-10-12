# Modified verson of Game of Nim
#
# References:
# Liu, T & Bryan, C 2016, tkl5/Nim-Game: Python code for the mathematical Nim puzzle game, featuring two players and computer hints, Retrieved 13th September 2020,
# <https://github.com/tkl5/Nim-Game>

import random

# the main function


def main():
    # Define an empty rocklist to append rocks to, define random integers, call functions
    List_Rock = []
    pile_random = random.randint(2, 5)
    rock_random = (2*pile_random)+1
    name1, name2 = get_players()

    player = name1  # Set current player to 1 (for switching later)

    get_board(List_Rock, pile_random, rock_random, player)  # Set initial board

    play_again(List_Rock, pile_random, rock_random, name1, name2, player)

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


def get_board(List_Rock, pile_random, rock_random, player):

    # Get initial board
    print("Let's look at the board now.")
    print("-" * 25)
    for i in range(0, pile_random):
        rock_random = random.randint(1, 8)
        print('Pile {}: {}'.format(i + 1, 'O' * rock_random))
        List_Rock.append(rock_random)
    print("-" * 25)

    # Call nim function to display computer hints
    nim_sum(List_Rock, pile_random)

# get_valid_input() function:
# Parameters :
#   -> modified list_main
#   -> random integer for piles
#   -> current player as string
# End : updates game board for following turns
# Returns : a string when input is invalid,


def get_valid_input(List_Rock, pile_random, player):

    # Begin loop that tests for valid input - if valid, break loop - if not, keep asking
    while True:
        stones = input('{}, how many stones to remove? '.format(player))
        pile_select = input('Pick a pile to remove from: ')

        # If all condiitons for input are CORRECT, break out of loop
        if (stones and pile_select) and (stones.isdigit()) and (pile_select.isdigit()):
            if (int(stones) > 0) and (int(pile_select) <= len(List_Rock)) and (int(pile_select) > 0):
                if (int(stones) <= List_Rock[int(pile_select) - 1]):
                    if (int(stones) != 0) and (int(pile_select) != 0):
                        break

        # If not, display this statement
        print("Hmmm. You entered an invalid value. Try again, {}.".format(player))

    # Update state
    List_Rock[int(pile_select) - 1] -= int(stones)

    # Keep playing game
    continue_game(List_Rock, pile_random, player)

# continue_game() function:
# Parameters :
#   -> modified list_main
#   -> random integer for piles
#   -> current player as string
# End : prints out updated game board after moves have been made, displays computer hint


def continue_game(List_Rock, pile_random, player):
    print("Let's look at the board now.")
    print("-" * 25)
    for i in range(0, pile_random):
        print("Pile {}: {}".format(i + 1, 'O' * List_Rock[i]))

    print("-" * 25)

    # In the case when game is over, do not display computer hint for empty board
    if List_Rock != [0] * len(List_Rock):
        nim_sum(List_Rock, pile_random)

    # print(List_Rock)

# play_again() function:
# Parameters :
#   -> modified list_main
#   -> random integer for piles
#   -> names of players
#   -> current palyer as string
# End : prints winner of game, asks if players want to play game again, determine current player


def play_again(List_Rock, pile_random, rock_random, name1, name2, player):

    # Begin loop to initiate player switching
    while True:
        get_valid_input(List_Rock, pile_random, player)

        # To determine winner, check if List_Rock contains all 0's on that player's turn
        if List_Rock == [0] * len(List_Rock):
            print("the winner of this round is {}!".format(player))
            user = input(
                "Do you want to play again? (y/n): ")

            if user.lower() == 'y':
                # reset all conditions, start the game again
                List_Rock = []
                pile_random = random.randint(2, 5)
                name1, name2 = get_players()
                player = name1
                get_board(List_Rock, pile_random, rock_random, player)
                get_valid_input(List_Rock, pile_random, player)

            else:
                break

        # switch players 2->1, 1->2
        if player == name1:
            player = name2

        else:
            player = name1

# nim_sum() function:
# Nim-sum: The cumulative XOR value of the number of coins/stones in each piles/heaps at any point of the game
# Parameters :
#   -> modified list_main
#   -> random integer for piles
# End : calculates nim sum and prints the computer hint for optimal moves


def nim_sum(List_Rock, pile_random):
    nim = 0

    # Calculate nim sum for all elements in the List_Rock
    for i in List_Rock:
        nim = nim ^ i

    print("Hint: nim sum is {}.".format(nim))

    # Determine how many rocks to remove from which pile
    stones_to_remove = max(List_Rock) - nim
    stones_to_remove = abs(stones_to_remove)

    # Logic for certain configurations on determining how many stones to remove from which pile
    # "List_Rock.index(max(List_Rock))+ 1 )" determines the index in List_Rock at which the biggest
    # pile of stones exists.
    if (nim > 0) and (len(List_Rock) > 2) and (nim != max(List_Rock)) and (nim != 1):
        print("Pick {} stones from pile {}".format(
            stones_to_remove, List_Rock.index(max(List_Rock)) + 1))

    if (nim > 0) and (len(List_Rock) > 2) and (nim == max(List_Rock)) and (nim != 1):
        print("Pick {} stones from pile {}.".format(
            nim, List_Rock.index(max(List_Rock)) + 1))

    if nim > 0 and len(List_Rock) <= 2 and (stones_to_remove != 0):
        print("Pick {} stones from pile {}".format(
            stones_to_remove, List_Rock.index(max(List_Rock)) + 1))

    if nim > 0 and len(List_Rock) <= 2 and (stones_to_remove == 0):
        print("Pick {} stones from pile {}".format(
            nim, List_Rock.index(max(List_Rock)) + 1))

    elif (nim == 1) and (len(List_Rock) <= 2):
        print("Pick {} stones from pile {}".format(
            nim, List_Rock.index(max(List_Rock)) + 1))

    if (nim == 1) and (nim == max(List_Rock)) and (nim != 0) and (len(List_Rock) > 2):
        print("Pick {} stones from pile {}".format(
            nim, List_Rock.index(max(List_Rock)) + 1))

    if nim == 0:
        print("Pick all stones from pile {}.".format(
            List_Rock.index(max(List_Rock)) + 1))


# Call the main function
main()
