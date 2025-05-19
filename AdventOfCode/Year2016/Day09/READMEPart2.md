# Information

I found a great algorithm on Reddit to this problem, following this guidance I was able to code my solution.

## Paste

In short the idea is to give each character in the input a weight, or
multiplier if you will. Then for each character, as the input is read,
increase its weight according to the decompression markers. This is roughly
the steps taken:

- Initialise all characters weights to 1
- Scan input one character at a time and
  - if it's a normal character, count its weight towards the total length
  - if it's the beginning of a marker, read the marker and multiply character
    weights forward in the input, according to the values of the marker.
- Print out the value of length

-----------------------------------------------------------------------------

Using the second example from the puzzle description
as an input; "X(8x2)(3x3)ABCY", the algorithm would run as follows:

1.

Weights: [111111111111111], length:  0

"X(8x2)(3x3)ABCY"
 ^

X is a normal character, so we add its weight to length.

2.

Weights: [111111111111111], length:  1

"X(8x2)(3x3)ABCY"
  ^

( is the beginning of a marker, so we read it and update the following
weights according to its values.

3.

Weights: [111111222222221], length:  1

"X(8x2)(3x3)ABCY"
       ^

( is the beginning of a marker, so we read it and update the following
weights according to its values.

4.

Weights: [111111222226661], length:  1

"X(8x2)(3x3)ABCY"
            ^

A is a normal character, so we add its weight to length.

5.

Weights: [111111222226661], length:  7

"X(8x2)(3x3)ABCY"
             ^

B is a normal character, so we add its weight to length.

6.

Weights: [111111222226661], length:  13

"X(8x2)(3x3)ABCY"
              ^

C is a normal character, so we add its weight to length.

7.

Weights: [111111222226661], length:  19

"X(8x2)(3x3)ABCY"
               ^

Y is a normal character, so we add its weight to length.

8.

Weights: [111111222226661], length:  20

"X(8x2)(3x3)ABCY"
                ^

We're at the end of input, so we read out the final result to be 20.