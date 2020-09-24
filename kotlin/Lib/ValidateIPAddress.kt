package LeetCode.ValidateIPAddress

/*
Validate IP Address
Test cases:
"172.16.254.1"
"172.016.254.1"
"0.0.0.00"
"2001:0db8:85a3:0:0:8A2E:0370:7334"
"256.256.256.256"
"0.0.0.-0"
"2001:0db8:85a3:00000:0:8A2E:0370:7334"
 */

fun validIPAddress(IP: String): String {
    if (isIPv4(IP)) return "IPv4"
    else if (isIPv6(IP)) return "IPv6"
    else return "Neither"
}

private fun isIPv4(IP: String): Boolean {
    val intParts = IP.split(".")
    if (intParts.size != 4) return false

    for (intPart in intParts) {
        val value = intPart.toIntOrNull()
        if (value !in 0..255
            || (intPart.length > 1 && intPart.startsWith("0"))
            || intPart.startsWith("-"))
            return false
    }
    return true
}

private fun isIPv6(IP: String): Boolean {
    val intParts = IP.split(":")
    if (intParts.size != 8) return false

    val max = 0xffff
    intParts.forEach { intPart ->
        val value = intPart.toIntOrNull(radix = 16)
        if (value !in 0..max || intPart.startsWith("-") || intPart.length !in 1..4) return false
    }
    return true
}