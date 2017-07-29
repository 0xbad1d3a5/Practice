def makeChange(coins, prev, value):

    if value <= 0:
        return 0

    new_list = []
    for p in prev:
        if sum(p) == value:
            return p
        else:
            for c in coins:
                new_list.append(p + [c])
    return makeChange(coins, new_list, value)

if __name__ == "__main__":
    
    coins = [1, 5, 10, 17]
    l = []
    for c in coins:
        l.append([c])
    print makeChange(coins, l, 1985)
