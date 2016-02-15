def twoSum(num, target):
    d = {}
    for i, v in enumerate(num):
        d[v] = i
    for i, v in enumerate(num):
        search = target - v
        if search in d and i != d[search]:
            return (i+1, d[search]+1)

if __name__ == "__main__":

    print(twoSum([3, 2, 4], 6))
