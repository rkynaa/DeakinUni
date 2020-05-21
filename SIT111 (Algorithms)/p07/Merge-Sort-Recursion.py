#non recursive version of merge from https://brilliant.org/wiki/merge/ 
def merge(left, right):
    result = []
    left_idx, right_idx = 0, 0
    while left_idx < len(left) and right_idx < len(right):
        # change the direction of this comparison to change the direction of the sort
        if left[left_idx] <= right[right_idx]:
            result.append(left[left_idx])
            left_idx += 1
        else:
            result.append(right[right_idx])
            right_idx += 1

    if left != []:
        result.extend(left[left_idx:])
    if right != []:
        result.extend(right[right_idx:])
    return result

# original merge sort from https://brilliant.org/wiki/merge/ 
def merge_sort(m):
    if len(m) <= 1:
        return m

    middle = len(m) // 2
    left = m[:middle]
    right = m[middle:]

    left = merge_sort(left)
    right = merge_sort(right)
    return list(merge(left, right))





# recursive version of the merge, by SW Loke
def rec_merge(left, right):
    if left == []:
    	return right
    
    if right == []:
    	return left

    if (left[0] < right[0]):
    	return [left[0]] + rec_merge(left[1:],right)
    else:
    	return [right[0]] + rec_merge(left,right[1:]) 
    	

# merge sort using recursive version of the merge, by SW Loke
def rec_merge_sort(m):
    if len(m) <= 1:
        return m

    middle = len(m) // 2
    left = m[:middle]
    right = m[middle:]

    left = rec_merge_sort(left)
    right = rec_merge_sort(right)
    return rec_merge(left, right)
    
    
 