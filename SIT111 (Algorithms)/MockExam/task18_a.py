def inter_two_list(listReturn, listA, listB):
    if (len(listA) != 0 and len(listB) != 0):
        if (len(listA) != 0 and listA[0] not in listReturn):
            listReturn.append(listA[0])
            del listA[0]
        if (len(listB) != 0 and listB[0] not in listReturn):
            listReturn.append(listB[0])
            del listB[0]
        inter_two_list(listReturn, listA, listB)


listA = [1, 2, 3]
listB = [3, 4, 5]
listReturn = []
inter_two_list(listReturn, listA, listB)

print(listReturn)
