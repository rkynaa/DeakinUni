def find_thirteen():
    count = 1
    list_13 = []
    for i in range(1, 1001):
        if (i % 13 == 0):
            list_13.append(i)

    for i in list_13:
        print("item #" + str(count) + ": " + str(i))
        count += 1


find_thirteen()
