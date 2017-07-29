def permutation(s, temp):
    length = len(s)
    for i, c in enumerate(s):
        if i-1 < length:
            ms = s[:i] + s[i+1:]
            permutation(ms, temp + c)
    if not s:
        print temp

def permutation1(string, temp, length):
    for index, char in enumerate(string):
        if length:
            substring_without_char = string[:i] + string[i+1:]
            permutation(substring_without_char, temp + char, length-1)
    if not length:
        print temp
    

if __name__ == "__main__":
    
    s = "abcd"
    permutation(s, "")
