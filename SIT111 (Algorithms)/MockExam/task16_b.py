def find_even(list_num):
    if (len(list_num) == 0):
        return 0
    else:
        if (list_num[0] % 2 == 0):
            del list_num[0]
            return 1 + find_even(list_num)
        else:
            del list_num[0]
            return 0 + find_even(list_num)


list_num = [1, 2, 3, 4, 5, 6, 7, 8, 9]
print("There are " + str(find_even(list_num)) + " even numbers in the list")
