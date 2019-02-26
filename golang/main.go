package golang

import (
	"fmt"

	"./libs"
)

func main() {
	fmt.Println("Hello")

	list := []int{1, 1, 2, 3}
	ans := libs.TwoSum(list, 2)
	fmt.Println(ans)
}
