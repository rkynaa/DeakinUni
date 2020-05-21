# Insertion sort

def myinsert(E,L):
    if L == []: #the case where L is empty,
        return [E] # just return a list with E in it
    else:# the case where L is not empty
        if E <= L[0]:# the case where E is smaller than the first, and so, E is smaller than all in L, since L is assumed sorted
            return [E] + L # return a list with E at the start (since E is smaller than all in L)
        else: # the case where E is bigger than the first element in L, that is, bigger than L[0]
            return [L[0]] + myinsert(E,L[1:])  # return the list with L[0] as head, and recursively, insert E somewhere in the tail of L (that is, in L[1:])


# this function does the insertion sort
def inssort(L):
    if L == []:
        # the sorted version of an empty list is an empty list
        return []
    else:
        # just printing for debugging purposes, can be removed
        print(L[1:])
        # sort the tail of the list first
        M = inssort(L[1:])
        # just printing for debugging purposes, can be removed
        print(M)
        # insert the head
        return myinsert(L[0],M)

# Selection sort

def ssort(L):
    # start with an unsorted list
    if L == []:
        # the sorted version of an empty list is an empty list
        return L
    else:
        # find the smallest from the unsorted list
        S = selectSmallest(L)
        # use the remove() function to remove S from L
        L.remove(S)
        # put S at the front of L (without S)
        return [S] + ssort(L)

def selectSmallest(L):
    # start with an unsorted list
    if len(L) == 1:
        return L[0]
    else:
        # the recursive step!
        minNumber = selectSmallest(L-1)
        if L[0] < minNumber:
            return L[0]
        else:
            return minNumber

# Merge sort
def rec_merge(left,right):
    if left == []:
        return right
    if right == []:
        return left
    if (left[0] < right[0]):
        return [left[0]] + rec_merge(left[1:],right)
    else:
        return[right[0]] + rec_merge(left,right[1:])

# merge sort using recursive version of the merge, by SW Loke
def rec_merge_sort(m):
    if len(m) <= 1:
        return m

    middle = len(m) // 2
    left = m[:middle]
    right = m[middle:]

    left = rec_merge_sort(left)
    right = rec_merge_sort(right)
    
    return rec_merge(left,right)


# Bubble sort

def bsort(L):
    # start with an unsorted list
    if len(L) <= 1:
        return L
    else:
        T = bsort(L-1) 
        if L[0] <= T[0]:
            return T.append(L[0])
        else:
            P = []
            P.append(L[0])
            P.append(T[0])
            Q = bsort(P)
            return Q.append(T[0])
