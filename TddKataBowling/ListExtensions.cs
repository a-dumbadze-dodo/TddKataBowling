using System.Collections.Generic;
using System.Linq;

namespace TddKataBowling {
    public static class ListExtensions {
        public static List<(T first, T second, T third)> ZipPreviousTriple<T>(this List<T> list) {
            var listWithDefaults = new List<T> {
                default,
                default
            }.Concat(list).ToList();
            return listWithDefaults
                .Zip(listWithDefaults.Skip(1), (first, second) => (first, second))
                .Zip(listWithDefaults.Skip(2), (previous, third) => {
                    var (first, second) = previous;
                    return (first, second, third);
                }).ToList();
        }

        public static List<(T first, T second)> ZipPreviousTuple<T>(this List<T> list) {
            var listWithDefaults = new List<T> {
                default
            }.Concat(list).ToList();
            return listWithDefaults
                .Zip(listWithDefaults.Skip(1), (first, second) => (first, second))
                .ToList();
        }
    }
}