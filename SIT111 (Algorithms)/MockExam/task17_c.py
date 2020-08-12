def knapsack(W, wt, val, n):
    # Base Case
    if n == 0 or W == 0:
        return (0, [])

    # If W of the n-th item is more than Knapsack of capacity
    # W, then this item cannot be included in the optimal solution

    if (wt[n-1] > W):
        return knapsack(W, wt, val, n-1)
    else:
        # suppose we keep item n−1
        (x1, l1) = knapsack(W-wt[n-1], wt, val, n-1)
        x = val[n-1] + x1
        # suppose we don't keep item n−1
        (y, l2) = knapsack(W, wt, val, n-1)
        if (x > y):
            # better to keep
            l = l1 + [(n-1)]
            return (x, l)
        else:
            # better not to keep
            return (y, l2)


capacity = 7
n_items = 4
weights = [2, 3, 4, 5]
values = [16, 19, 23, 28]

print(knapsack(capacity, weights, values, n_items))
