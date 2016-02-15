def reverseString(s):
    
    return ' '.join([word[::-1] for word in s[::-1].split(' ')])

def reverseStringKeepSpaces(s):

    original = s.split(' ')
    reverse = [word[::-1] for word in s[::-1].split(' ') if word]
    result = []
    count = 0

    for word in original:
        if word:
            result.append(reverse[count])
            count += 1
        else:
            result.append(word)
    return ' '.join(result)

if __name__ == "__main__":
    
    s = "This is a   string."
    print s
    print reverseString(s)
    print reverseStringKeepSpaces(s)
