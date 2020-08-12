# def mystfunc(n):
#     if (n <= 1):
#         return n
#     x = mystfunc(n-1)
#     return n + x

# print(mystfunc(5))

# def subset(L):
#     listRes = []
#     listRes.append([])
#     if (len(L) > 0):
#         for elm in L:
#             listRes.append([elm])
#         if (len(L) > 1):
#             tempL = []
#             for elm1 in L:
#                 for elm2 in L:
#                     if elm1 != elm2:
#                         tempL.append(elm1)
#                         tempL.append(elm2)
#                         listRes.append(tempL)
#                     tempL = []
#     return listRes

# print(subset([1, 2, 3]))

# def subsets(L):
#     temp_res = []
#     subsets_util(L, [0 for i in range(len(L))], temp_res, 0)
#     result = []
#     for i in temp_res:
#         temp = []
#         for j in range(len(i)):
#             if (i[j] == 1):
#                 temp.append(L[j])
#         result.append(temp)
#     return result

# def subsets_util(L,temp,result,index):
#     if (index == len(L)):
#         result.append([i for i in temp])
#         return
#     temp[index] = 0
#     subsets_util(L, temp, result, index + 1)
#     temp[index] = 1
#     subsets_util(L, temp, result, index + 1)

# print(subsets([1,2,3,4]))

# Python code has been modified into descending order
# def bubblesort(alist):
#     size = len(alist)
#     for i in range(size):
#         index = alist[i]
#         for j in range(size - 1, i, -1):
#             # changed from less than to more than
#             if alist[j] > alist[j-1]:
#                 temp = alist[j-1]
#                 alist[j-1] = alist[j]
#                 alist[j] = temp

# listA = [2, 6, 3, 5, 1]
# listB = [34,8,34,0,80,12,90,2,20]
# print("before   : " + str(listB))
# bubblesort(listB)
# print("after    : " + str(listB))

# def BinarySearchIterative(item_list, item):
#     left = 0
#     right = len(item_list) - 1

#     while (left <= right):
#         mid = (left + right)//2
#         if (item_list[mid] == item):
#             return mid
#         else:
#             if (item < item_list[mid]):
#                 right = mid - 1
#             else:
#                 left = mid + 1
    
#     return -1

# listA = [1, 1, 2, 3, 4, 4, 5, 5, 6, 7, 7, 7, 7, 8, 8, 8, 9, 9, 9, 9]
# print(BinarySearchIterative(listA, 7))

def df_search(graph, vertex, visits, item):
    visits = visits + [vertex]
    if (item == vertex):
        return(visits, True)
    else:
        answer = False
    for neighbor in graph[vertex]:
        if neighbor not in visits:
            (visits, answer) = df_search(graph, neighbor, visits, item)
            if (answer):
                break
    return (visits, answer)

adjacency_matrix = {11:[7, 6, 3], 7:[9], 6:[6], 3:[], 9:[6], 6:[10], 10:[]}
print(df_search(adjacency_matrix, 6, [], 7))