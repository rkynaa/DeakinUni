#A recursive version of a program to sum all elements of a list:

def sum(L):
    if L == []:
        return 0
    else:
        return L[0] + sum(L[1:])



#usage example:

sum([1,2,3,1])





#A recursive version of insertion sort, uses two functions:



# this function inserts an element E into the list L at the right position, assuming L is sorted;

# for example, myinsert(4,[]) returns [4]

# myinsert(3,[1,2,3,4,5]) returns [1,2,3,3,4,5]

#  myinsert(3,[1,2,3]) returns [1,2,3,3]

# etc

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
        return []  # the sorted version of an empty list is an empty list
    else:
        print(L[1:]) # just printing for debugging purposes, can be removed
        M = inssort(L[1:]) # sort the tail of the list first, that is, sort L[1:], and getting the result stored in M
        print(M) # just printing for debugging purposes, can be removed
        return myinsert(L[0],M) # insert the head (that is, L[0]) in the sorted tail (that is, M) using myinsert



#*Note both functions are recursive

#usage
inssort([1,2,8,2,8,3,7,4,6])
