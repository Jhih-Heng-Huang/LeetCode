cmake_minimum_required(VERSION 3.5)

project(LeetCodeCSharp VERSION 0.1.0 LANGUAGES CSharp)
set(EXECUTABLE_OUTPUT_PATH ${PROJECT_SOURCE_DIR}/bin/${CMAKE_BUILD_TYPE})
set(LIBRARY_OUTPUT_PATH ${PROJECT_SOURCE_DIR}/lib/${CMAKE_BUILD_TYPE})
set(CMAKE_LIBRARY_PATH ${PROJECT_SOURCE_DIR}/lib/${CMAKE_BUILD_TYPE})

include(CSharpUtilities)

add_subdirectory(${PROJECT_SOURCE_DIR}/src)