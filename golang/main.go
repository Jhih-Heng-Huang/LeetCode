package main

import (
	"fmt"

	algs "./libs"
)

func main() {
	fmt.Println("Hello")

	list := []int{1, 1, 2, 3}
	ans := algs.TwoSum(list, 2)
	fmt.Println(ans)
}
