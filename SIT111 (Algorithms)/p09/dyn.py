#recursiveversion
def doknapsack(weight, wt, val, n):
    # Base Case
    if n == 0 or weight == 0:
        return (0,[])

    # If weight of the n-th item is more than Knapsack of capacity
    # W, then this item cannot be included in the optimal solution

    if (wt[n-1] > weight):
        return doknapsack(weight, wt, val, n-1)
    else:
        # suppose we keep item n−1
        (x1, l1) = doknapsack(weight, wt[n-1], wt, val, n-1)
        x = val[n-1] + x1
        # suppose we don't keep item n−1
        (y, l2) = doknapsack(weight, wt, val, n-1)
        if (x > y):
            # better to keep
            l = l1 + [(n-1)]
            return (x, l)
        else:
            # better not to keep
            return (y, l2)

# dynamic programming ver
def dpKnapsack(W, wt, val, n):
    t = [[0 for j in range(W+1)] for i in range(n+1)]
    c = [[[] for j in range(W+1)] for i in range(n+1)]

    # 0 to W
    for j in range(0,W+1):
        t[0][j]=0
        c[0][j]=[]
    # 1 to n
    for i in range(1,n+1):
        # 0 to W
        for j in range(0,W+1):
            if wt[i-1] > j:
                t[i][j] = t[i-1][j]
                c[i][j] = c[i-1][j]
            else:
                x = t[i-1][j-wt[i-1]] + val[i-1]
                y=t[i-1][j]
                # keep item
                if (x > y):
                    t[i][j] = x
                    c[i][j] = c[i-1][j-wt[i-1]] + [(i-1)]
                else:
                    t[i][j] = y
                    c[i][j] = c[i-1][j]
    return(t[n][W],c[n][W])

# Recursion fibobacci
def Fibonacci(inp): 
    if inp < 0: 
        print("Incorrect input") 
    # First Fibonacci number is 0 
    elif inp == 1: 
        return 0
    # Second Fibonacci number is 1 
    elif inp == 2: 
        return 1
    else: 
        return Fibonacci(inp-1) + Fibonacci(inp-2) 

# Dynamic fibonacci
def dynFibonacci(n, table = []):
    #this does the same thing except it doesn't change the reference to `table`
    while len(table) < n+1:
        table.append(0)
    # Base case
    if n <= 1:
       return n
    # recursive case
    else:
        if table[n-1] ==  0:
           table[n-1] = dynFibonacci(n-1)

        if table[n-2] ==  0:
           table[n-2] = dynFibonacci(n-2)

        table[n] = table[n-2] + table[n-1]
   return table[n]