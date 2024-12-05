using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
class Day4{

    public static void TotalRun() {
        FirstPart();
        SecondPart();
    }

    public static void FirstPart() {
        string inputClean = AoCMethods.Injest(input);

        List<string> lines = inputClean.Split(",").ToList();
        /*
        x y ------>
        |
        |
        |
        V
        */
        int totalNumberOfXMAS = 0;
        for(int x = 0; x < lines.Count; x++) {
            for(int y = 0; y < lines[x].Length; y++) {
                if(lines[x][y] == 'X') {
                    // check each direction
                        // check up
                        if(x >= 3 && lines[x-1][y] == 'M' && lines[x-2][y] == 'A' && lines[x-3][y] == 'S') {
                            totalNumberOfXMAS++;
                        }
                        // check up-right
                        if(x >= 3 && lines[x].Length - y >= 4 && lines[x-1][y+1] == 'M' && lines[x-2][y+2] == 'A' && lines[x-3][y+3] == 'S') {
                            totalNumberOfXMAS++;
                        }
                        // check right TODO continue here!!
                        if(lines[x].Length - y >= 4 && lines[x][y+1] == 'M' && lines[x][y+2] == 'A' && lines[x][y+3] == 'S') {
                            totalNumberOfXMAS++;
                        }
                        // check right-down
                        if(lines[x].Length - y >= 4 && lines.Count - x >= 4 && lines[x+1][y+1] == 'M' && lines[x+2][y+2] == 'A' && lines[x+3][y+3] == 'S') {
                            totalNumberOfXMAS++;
                        }
                        // check down
                        if(lines.Count - x >= 4 && lines[x+1][y] == 'M' && lines[x+2][y] == 'A' && lines[x+3][y] == 'S') {
                            totalNumberOfXMAS++;
                        }
                        // check down-left
                        if(lines.Count - x >= 4 && y >= 3 && lines[x+1][y-1] == 'M' && lines[x+2][y-2] == 'A' && lines[x+3][y-3] == 'S') {
                            totalNumberOfXMAS++;
                        }
                        // check left
                        if(y >= 3 && lines[x][y-1] == 'M' && lines[x][y-2] == 'A' && lines[x][y-3] == 'S') {
                            totalNumberOfXMAS++;
                        }
                        // check left-up
                        if(y >= 3 && x >= 3 && lines[x-1][y-1] == 'M' && lines[x-2][y-2] == 'A' && lines[x-3][y-3] == 'S') {
                            totalNumberOfXMAS++;
                        }
                }
            }
        }
        Console.WriteLine("After processing the word search, we found XMAS {0} times", totalNumberOfXMAS);
    }

    public static void SecondPart() {
        string inputClean = AoCMethods.Injest(input);

        List<string> lines = inputClean.Split(",").ToList();
        /*
        x y ------>
        |
        |
        |
        V
        */
        int totalNumberOfXMAS = 0;
        for(int x = 0; x < lines.Count; x++) {
            for(int y = 0; y < lines[x].Length; y++) {
                if(lines[x][y] == 'A') {
                    if(lines[x].Length - y >= 2 && y >= 1 && lines.Count - x >= 2 && x >= 1) {
                        List<char> firstDiag = new List<char>();
                        List<char> secondDiag = new List<char>();
                        firstDiag.Add(lines[x-1][y-1]);
                        firstDiag.Add(lines[x+1][y+1]);
                        secondDiag.Add(lines[x-1][y+1]);
                        secondDiag.Add(lines[x+1][y-1]);
                        if(firstDiag.Contains('M') && firstDiag.Contains('S') && secondDiag.Contains('M') && secondDiag.Contains('S')) {
                            Console.WriteLine("We found a MAS X at position {0},{1}", x, y);
                            totalNumberOfXMAS++;
                        }
                    }
                }
            }
        }
        Console.WriteLine("After processing the word search for X-MASes, we found X-MAS {0} times", totalNumberOfXMAS);
    }

    private static string testInput = @"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX";
    private static string input = @"XMMAMXMMSMXMMXMSMAXMAXSXMXXMXSMXXASMXSXMXMXMXMXXXXMASMSMAMMMSSSMASXMXSASXMXAAXXMMXAMXSXMASXAXMAMXXXMSAMSAMXXXMAXSAMXSAMMXXXSSMSMSSXMSMAAXXMX
SXSAXXXXXXAMAMXAXXMMSMSAMXAMAMMMMXMXAMXMAMASAMMSXMASXAAMAXMAAAAXAMXMMMASMMMMMMSMMXAMASASMSMSMSMSMSASAAMSAMXMASAAMSXAMAMXSMMXAAXAAAMSASMXMASX
SXSMSMXAMSSMMASXSSMMAAXAMXAMMXAAMASMMSAXMXAXAXAXMASXMSMSASMMMXMMMSAMAMXMAXMAAAMAMSXMAXMMAMAAXAAAXMMMMMXSAMSSMMXSXAMMSMMMXAASMMMMMMMSASXAAXXA
SAXAAAMAAAXAXMAMMMAMMSXMMSSMSMSMSASAAMXMSMSMSMSMSSMXAAXMASMASAXAAMXSASMXMASXSMMAMMAMASMMSMSMSMSMMMSSXMASAMAMXMAXMMMMAAAXMSMXXAXMAXXMAMXXMAXX
MMMSMSAXXASMMSASMSAMXXAAMAMASMMXMASMMSSMSAMAMAXASAMXSXXMXMXASMSMSSMSXXMAMXMAMMSMSXXMMSAAXMAXMAMXAMASAMXSSMXSAMXXAXMSXSSXXMAXSMSSXXXMSMSMSSSS
SAAXMAXSMXMXMSAMXSASASMMMMMAMASMMAMAXSXAMMMMMAMMMXMAMMSMMMMMMAXMXAMXAMSMMAMAMAMASMXXXMMMMSMMSXSXSMASXMXMAXXSASMMXSMMAMAXSMMMSAXMMSXAXAAAXAAM
SMSSMXMXMMAMXMAMAXXMAXSAMXMASXMAMASMMSMMMAAXMAMXMASMSAAAAXASXSSMSSMMXMAAXSSMSMMAMAMASXSAXAXXAASAMMMMMSMSMMMXAAAMASAMMMAMXAXAMMMAASMMMSMSMMMM
XXXMXAMAXAAMAMMXSXXMAMSSMMSXXAMXMMSXAXAXASXSMSAMXXXAMXSSMSASMMAAAAXAXMXSAAAXSAMXSAMXMASASMSMMSMAMSXAAMAAAAXXXXAMXSAMXMMSSMMSSXMMMMAAAXMMXMAS
SMMMMMSMSXXXXSAAMAMMSMXXXAXMSMSAMXMMMMSMXXMMXMASMMMMMAXAXMXMASXMMSMMMSAMXMAMMAMASAMXMAMAMXAXXAMMMMXMMXXSSMSMMSMMXSAMXMAMXMAMAXMXXXXMXXAMXSAS
MAAAAMAMXAXSMMMXSAMAMMMSMXSAAASASAMASAMXAMAXMAXAMSAASAMXXMASMMASMXMXAAAMXXAAXAMMSXMSMMXAMXSXMASAASMSAAMAMMAMAAAAAMAXMMMXMMSSSMMMMSXAMMSMMMAS
XSSXXXXSMSMAAXAMSAMMSASXAXMMMAMASXXAMSSMSSSMSMSAMMSMSASXMSASASAMXAMMXSSMXMMSSSSXMAXMAMSXSAXAMASMXMAMMSAAMSAMMXMMMSAMSMMAAXAAMMSAAAMXMAMASMMM
XMAXSSMSAMSXMMSXSXMASXSMSMMMXXMASMSSMXSAAAAAAMMAMAMMSASMMMASAMXMMASAAMXMSAAMXAXMMMSMAMAMMAXXMAXMSMMMAXXMMSASMMSAXAMSAASMSMMSMAMMMMSAMMSAMAXS
MMAMMAAMAMAXSAMXXXXXMMSMMAAAAXSAMAAAAAMMMXMMMXXAMXSAMXMAAMMMMMMSSSXMASAMXSASMSMSAAAXAMAAMMMSSXSAMSXMMMSSMSAMAASXMASXMXMXAXAXMXMSXMSASAMXSXMM
ASXMXAMMXMXXMASMSXSASAMASXMMSXXAMMMSMXMSSSMSXSSXSAMXSMSXMMMAXMAXMAXXAMAXAMXSAAASMSMSMSASAMXAAASMXAXXXAAAAMMMMMSXAXAXXMMSMMMSMSXSAASAMXSMMMSS
MMASMSMMXSSMSAMXAASAMSMMMMAXXASXMMXMASXXMAAMAMAMMXXAMXAXMASXSMSSSMSMMSAMSSMMXMMMMXXXAXAMASMMSMXXSMSMSSSMMMAMAMXXMMMASAMXAAAAMSAXMMMXMMMXAAAA
XMAMXXAXAMMXMASMSMMXMAMSASAMXXAXASXMAMMASMMMAMXMXMMSSMMMSASAAAAAAXAAAMAMXAMAAMASXXMMSMXSAMXAMXXMAXAAXAAMSMXSASASXXMASMMSMMSSSMMMSAMXSXMSMMSS
SMSSMSSMMSAXSAMMMAXXXSXSASMMMSMSMMAMMMMAMAASMSMSXAMAAAAAMXMMMMMXMMMSMSSMSAMSXSAMAMXAAAXMASMSSMMXMXMXMSMMAAMSAMASXXMASXXAXXAMAMXAXAXAXAMXMAMX
AMAAAMXAMXAMMAMXSXMMMMAXXMAXMAAMASXMASMMSMMXAAAXAMMSSMMMSAMXXAMAAAXAXXAAMXMAMMASXAMMSSXSAMAMAMSSSXMSAXXSMMMMMMAMAMMXSMSSXSAXAMMMSMMMSAMXMASM
MMSMMSMSMSXXMXMXAMMAAMMMMSXSSMSMAMASASAAAASMSMSSSMAMAXAXSASMSASXSSSMSSMMMSMMXSAMMSSMMAMAAMAMAAAAMAAMSMMMAAMAMMXSSSMSMMAMMSAMSSMMAMAAMAXSSMSX
XAXXMAAAAMASMAMXMASXSSMAXMAXAAXMMMXMASMMXSMAAAXAAMXMMMAMSXMXSASAMXAMXMASXXAAAMASAAAXMASXMSMMSMMMMMMMAMASMXSASXXXXAXSAMASXMAMAAMSMSMSSMMMAAXM
MMMMMMXMAMAAMASAMMMAMAXSXMMMMAMAXXMMMMXAMMMSMSMMMMSXMASMXAMASXMASXMMAMMMASMMSSMMMSXMXAMAASAAXASMXMAXMMAXAASMMMSSSMASAMASXSSMSXMAXXAAXXASMMMX
AMASXMMSAMMSMMMASXMSSSMMXXAAXAMXMMSAMMMSXSAMXXAXAXMAMXMASXMAMAMAMMASXSASMXMXXAAXXAASXMMSMMMMMAMXAXMSXMMSMXMMAXAAAXMSAMAXAXAAXSSXSMSMMSMSXMAM
XMASAAASASXMAMXAMXAAAMAMMSSSSMSMSAXASMAXXMMMMMMXMMSAMAXMXXMASMMSSXMXAMAMXMXXXSMMMMMMAXAMXMSXMSMSMSAAXAASMMASXSMSMMXXAMMXSXMMMMXAAAAAAAAMAXSA
SMASXMMSAMXXMMASMMMMSMAMAXMAXXAAXSSXMMASMMAAAAMASMSASMSXMSMASAAXXMXMSMXMASMMMXAAMASMMMXSAMMSMAAAAAXMXMXXASAMXMXAMSMSSMSAAASMSSMSMXMSSSXSAMXS
XMAXAXMMMMMMXMMMAXMAXMASXXSSSSMSMASXAMASASXSSMXAMAXAMAAXAAMXSMMMSMAAAAMSAMAAXSSMSASAXAASAMAAXSSMXMAXSMMMAMXSAXSASAAMMAMMXMMAAXAAMMMMAAAMMSXA
SSXSAMAAAAASXMXSMMSSMSXSXMAMAAAMMAMSMMASMMAMAAMSMMMSSSMMSASASMAAAXSSMSMMASXXMAXXMASMMMMSSMSSMMAXXSMAAXMASXXMAXSXSMMMMMXMXSMMMMSMMAAMMMMMASXM
MAMMXSMSMSMSAMXAAAAAXSAMXAMMSMMMMXMAMSMMMMSMAMAAAMAMAAXXMSMASMXXMMMAMAMSMMASMMMMSAMXSAMMAMXMAXXMMASXSSMXMASMXMMASAMSAMSAMXAAXXMASXSSXAXMASMX
XMASAXXMXXXSAMXMMMSMMXMAMXSAMXSMAMMAXSAMXAXXXXXSSMAXSMMXXXMAMMSMXASAMMMMMMAMAAMXMAMXSAXXAMMSSMSASAMXMXMXMASXMAMAMAMSASXMASMMMAMAMAAAXMXMASAX
SXMMXSAMXMMSAMSXSAMAMMXMSMAAAAMMASMSMSAMMMXMMSAMXXSXMXMMXMXSAAAAMMSAMMAAAMAXMXMSSSMASXMSXXAAAASMMXSXMASXMXSASXMAMSMMMMASMMSSMXMAMMMMMMAMAMXM
XXMAXMAMMMAMAMXAMAMAMAAMAASXMASMXSXAASXMXSAAAXAXAMMASAMXSMAXMSSSSMMMSSSSSSXSMSMMAAMXMSXAXMSSMMMXXMAMSAMXXASXMAXAMXAMXMASMAAXAAXMMSMSAXXMMSSM
AMMXXMAMXMSMMMMSMMSSMSXSAXMAMXAMXXXMMMXSASMSMSSMASXSMAMMSMASXXMAXXAAAXXAXXAAAXAMSMMAAMMMSXAAXMXMASMMXSXXMASMSSMMMSAMAMASMMSSSSXSAAAMMSMAAAMA
SXSAMSAMMXMAAAAMAXAMMXMAXXMXSAAMXMASXMAMMSAMAAXSAMXAXSMAXMASAAMXMAMMSSMMMMSMMMSMAMMMAMXXMMSSMSMSASMSAMSXSAMMAAAXXSAMXMAXAXMAMAAMSMMMASMMMSSX
MAMAXXMMXAXXXMSMSMMSSXMASMSAMXSMSAXXAMASXSAMMMXMMSMMMXXSXMXXXAMXAXXMAMXAAXXAAAMMMMSSMMSAMXAMAAAMAXAMAMXXAAMMMSMMXMASMMMSSMSAMMXMAXAMXSAXMXMM
MXMSMSMSMMSXSAMXMAXAMMXMXXMAMAMAXSAMXSXSASXMASAAAAMXMXAMMSMMXMAXSAAMXSSMSSSMMMSAXAMAAAMAXMASMMSMSMSMSAMXSMMSMMMXAXAMAXAAAXXASXMSSSMSXSMMXAXA
SXMXAAXMAMAMMAMAXAMXSASXMSXSASMMMXXMAMAMXMASXMSSMSAMXMSMAAAXXXMAMMMXMXMXAMAAAASAMSMSMMXMMSMMXSAAXAAAMAXAXAXSAMSSMSSSMMMMXSSMMAXAMXAAMMMSSMSS
MAMMSMXSAMSMSAMXSMAAMMSAAXAXMXAXAMSAASAMMSAMMMMXMXMAMMAXSMSMASMMMXMAAMMMSSSMMXSXAXAXASASAMXMXMASMXMMSSMMSSMSAMAAAAAAXMASAMASMXMAMMXMXXAMAAAA
SAMAASXMXMXASAXMAXAMXAXMMMMMXSXMSAASXMASAMASMAXMASXSSMMMMXAAXAAASMSMXSAAMXMASMMMXMAMASASXXAAAAXMXXXAAXAAXMASMMSMMMSMMMSMMSAMXAXMSSMMMMMSMMMM
SASMMMMSSMMMMMSMXSXMMXXAAAAAAAASMMAMSMXMMSXMXMSMMXXAAMXAMSXSAXSMSAAAAMMXXASAMAASXMAMXMAMASXSMSMSSSMMSSMMSMAMMAXAAMAMAXMAMXAASMMMAMAAMAMXMMSM
SXMAXSAAXAXXAXAAAXAXAXSSSSSMSSXXAXXSXSAMXMMSXMAXMASAMXSSXMAXAMMAMMMMMSAMSAMXXMMMSAMXAMXMMXMAXAAXXXAAXAAAXMAXMXSSMSASMMSAMSXMAAAMASMMSASMMAAX
SAMMMMMSSSMSMSMMSSMMXMAMXAAXAXMSMMSMASMXAAMAASAXMAMXXAXAAMAMAMMAMXXMXMAXMXMXXSXMXMAMXSXXXXAMSMMMMSMMSMMMSSXSAAXAXMMMXASAMSXMXSMMMSAXSAMAMSMS
SXSXMSAAAAAAASXXXAMASMSMMSMMMSXAAMAMMMSSXMMSAMASMSSMSMMMXMSSMMSSMAXSAMSMXAASMMMSAMXMXMMSASAMXXAAMXAAXXAXAAAMMMSAMXAXMXXAAMASAMASXMXMMAMXMXAS
MAAXMMMSMMSMSMMMMAMASAAMMAXAXAXSSSMMSAMMSXAXSMAMAAMAXXMSMAAAAXAXMAMSASAMXMSAMAAXASXSMAAMAMAMAXMSASMMSSMMMSMSXAXXASMSSSSSMSAMASAAMMAMXAMSAMAM
SMMSSMXXAXXMAAMSSMMMMXMSSMSSSSXMAAXAMAMAMMMMXMAMMMMSMMMAAMSMMMMSMSXSXMASXSMMSSXXMMAASMMSMSMMXSAMMMAMMXMAXXXAMASMMAXAAMAMAMXSXMAXSSXSAASMXMAM
AAXAAMAMAMMSXSAAAXXAXXXXAMSAAMMMSMMSXMMSMSMAXASAMXSASASMMXMAXSXSAMAXMMXMMAAXAAMSSMSMMMAAAXMASMAMXXAXMASMSMXMASXMSMMMSMMMMMAXMASXMAMXMSXMASXS
MMMSSMASMMMAMMMMSMSMSMMSAMMMMMAXXXAXASAXAAAXAMXAMXSASXSXXSSSMAAMAMMMASMMSSMMMXMAAMXMAMXSSXMXSMMMMSMXSAMAAAAXSXMXAXAXAXMASMMXSAAMMAMMSMAMMSXM
XMAXAXMSASMAMSSMXAAAAAXXAMXAAXXAMXXSMMAMSMXSSXSXMMMMMAMMXAAAMMSMAMAAMAAMAXXMAXMSMMASMSAMMXMMMMMAXAAXMAXSASXSMAMSMSMSMMSASAAMXMXAMAMXASAMAMAS
XMXXAMXMAXXAMASMMSMMSSMSSMSSSSMXXSXMXMAMAMXAMAMXMXMMXSASAMMMSAXXXXXSXMSMASMMSAMMAMASAMXSXAXAAAMSSMSMMMMXAAXAXXMAXAASXXMSSMMMAXSSXSSSMSXMASAM
MSSSMSXMSMMXMXSXAMAAAAAXAAXXMAMSAMMSASASASXMMSMSMSMAAXSAMXMAMXSMSSMMMXMMMSAAXAASAMXXMAMMMXXMSXSAMXMMMSAMXMXMMMSXSMSMXXMASMASMMMAMAAMXMASAMAS
AAAAAAXAAAASMMMMSMMMXMMSMMMSMAMMAMASASASASASAMXAAAMMMSAMXAMASMMAAXAASASAAMMMSMMSAMXSMSASXSSXAMMXMAMAXMMSASXSAAAXAMAMMXMXXMAAMAXAAMXMASMMASAM
SMSMMMMASMMMAAMXMXSMXSAMXAAAMASMMMXSXMAMXSAMXMSMSMSAMXAXSXSASAMAMSSMSASMMMAXXXMXMMMAAMASAAAMMSXXXXMSMMXSXSASMSSSMSAXMXSMSMSSSSSMSXASAMAMAMAX
XMMMMXMAMAXSMMSSMAAAAMASXMXMSAMAMXMMMMMXXMAXMASAXXSMSSXMSAMXSAMMMAAXMAMASXMSMSSMMAMMXMAMMMMSASXXSMAXAMASXMMMXXAXXMMMXAAXMAAAXMAXMXXSASMMSSSS
XSAMXAMXSMMSMSAAMSMMMSAMASXAMASAMSAMXAAMXSSMXXMAMMMSMAMMXAXASAMXMSXMMAMAMAMAMAAASXSXAMXMAMXMASMMMSASAMAXASXXXMAMMMSAMMSMMMMSXXXMXXMMAMAAAAAX
SSSSSXMXAMAXXMXMMMMSAMXSAMMMMXAMXXASXMSXMMMMMSMMSMSAMXAXXAAXMMSAXMMSSSSSSSMAMSSMMASXXSASASAMMMAAASMSXMASXMMXSMAMXAMXMAAAMAMXMSMMMMAMXMMXMMMM
XMAXAMXXAMXSMXSSMSXSMMMMASAXXXMASMMMAXMASXMAAXAAAXMAMSSMMSMXAAMXXAAXAAAXAXXXXXAAMSMMMSASXMXMASMMMSAMXAMXMASMMMAXMXSASMSMMSSXAAXMASMMMXMAXAXX
AASXMXAXSMMXAAXAAAXSASXSXSMXXAMXMAMSMMMAMAMMXSMMSMSAMMAAAXXSMMSMSMMMMMMMMMXSMSMMMMAAAMMMXSASAMAMAMAMAXXASAMAASMSMXMAXXAAAXAXSMXXAMAMAASXSMMS
XXXMXMMXAAMSSXSMMMXSAMASAMAMSSMXMAMSASMASMMSAMXSAMXMASMMMSXMXMAAAAASMMAAXAAMAXSAMXSMXSASXSAMMXAMAXAMAASXSASMMMMAMXMMMSSMMXMMMXAMXSSMSMSMAMAX
MMMAXAXXSAMXXXMASXAMAMAMMMAMMXAAXXXSAMSAMMASAMXMAMXMASMAAXAAASMSSSMSASMSXMXSSMXXSAXAXXAXAMAMSSSXMSSMXMSASAMXSXSAMAAAAXMXSAXAXMMSAAXAAAMXAMSS
AAAMMSMMMASAXMMMAMXSXMASXSSSMMMMSMAMXMMMXMXSMMASAMSMMSXMMSMSMSAAAMXSMMXMASAAAMAMMMSSSMMMSSMMMAMAMAAMXAMMMAMAAASMSXSMSXSASMMSXMASMMMSMSMMXSMX
MMSXAAAXSAMXMMAMAXAMXMXAMMMMMXAAAMXMMSAMXSAMAMASASAAXMMSAXXXAMMMMMAMXSASAMMSMMAMAMXAMXMAXAAXMAMMMSSSMMSXSXMMMMMAMAMAAAMASAMXAMASAXAAXXASMSAA
SAXMSSXMMMMAAMAXSMMAAXMMAXAAMMMXMMAMXSASMMAMXMASMSMXMMAXXAMMMMXMAMXSAMXMASAXXSXMAMXMSAMXMXSMMMSMAMXXAXMASXXAXASAMAMMMSMAMAMXAMASMMSXMXAMAMXS
AAXAAMXSAAMMSSMSAASXMSSXSSMSMSAMSMMXMXMAAMMSSMXSAMXSXMMMMAMAMSASASXMXSAMAMXMAXMASMSXSASMSMMAAAAMAMSSSMMAMXSASXSASASAAXMMSSMSMMASXMASXMSMSMAX
MSMMMSASMXXAAAXMMMMAAAXMAXXAAMSMAASXMAMMSXAAAXAMXMASXAAMSASAXMAXAXXASMXMMSSMSMMXAAXAXAMAAASMMSSSXSAMXAMXMMSASXSMMXXMSSSXXAAAXMASAXAXXAAAAMXM
SXASAMASASMMMXMXAMSMMMSMAMMASAMMSMMASAMXMMMSSMSSSMAMSSMXSXSMSMSMMMMMMMXAXAMXXAMSMSMSMSMSMMMSAAXXMMMSSMMSXAMAMAXMMXSXXAMXSMMMXXAMMAMXMXMXAMXA
ASAMXMMMAMMAMMMXMXXMAXAMAXSAXASAMASMSASAXAXAAMXAAMMMXXMASMSAAAAXMXAXAXMAMXSASAMAAAAAMAAAXAASMMSSMAMMAAAXASMSMSMASMASMAMMMAAXSMAMSSMASXSMSAXS
MMMMXSAMSMSASAAXSASXSSMSAXMXSAMASAMXSAMASMMMSMMMMSSSMAMAXXMSMSMMMSMSMMMSXXMASMMMSMSSMMSMSMMXASAMXASMSMMSAXMAAMSAMAXXMAMAMMAASXSMAXXXSAMAMXMX
XMAMAMXSAASASMSMAAXMMAXMXSAMXMMXMXMAMAMXMAAAAAXXXXAASMMMSMMXXAXAXAAAAAAAAXMMMAAXXMAXXMAMXAMXXMASXMSAXMASASMMXMMXSSMMSSSSSXMXXAXMXXMXMAMXMSAM
MAAMMMMMMXMAMMXXMSMSSXMSAMXAAMSXAAMAXAMXSSMSSSMSMMSMMSMAAAMAXMSSSMSMSMSSSMMAMMMXSMSXXMAMSAMSSMAMAXMXMMAMXMAXSAAAMAMXAMMAMXMMMXMSAMSASAMAMSAM
AXSMSAXMMMMSMMXAXXAAASXXMASMMXAMSMXMSMSMXXAMAAAXXAAAXXMXXMMXSXAXMAMAXMXAXMXAMXMASXAAMSAMSAXAAMSSXMSAMMMXSSXMASMMSMMMMXMASAAASASMAXSAMAMXMSAM
SMMASASMSAAAAMSMMMMMMMMAMXMSSXSMXXAMAXAASXXMSMMMMSMSMXXMSSMMAAMXXMMMAMXMSXSXSAMXSMMMMAMMSAMSSMMXMASASXSAXMAXXAMXAAMMAMSAMMSASXSMXMMMMSSMMSAM
MAMAMAMASMSSXMAMAXXASASAXAAAMAMAMSMSAXMSMAAXXSAAXXAXXXMMAAASXXSAMXASAMMXXMAASAMXSASXMAMMXMXAMAXXMAMAAAMSMMSMAMSSSXSMAXMAXMMMMAMMAMXMAAAAMMXS
MAMMMXMXMXXMASASMSSMMASASMSMMAMAMAMAMASAXSXMASXSMMAMASMMSSMMMAAMSSMSASAMXAMXMASXMXMASXSXAXMASXMXMXSMMXMAXMASAAMAXAMXSMMSMXAAAAMSXSAMMSSMMMAS
SMSMMASAMMXMMSASXMASMAMAMAAXMASASMSAMXXAXMSAXMAMAMMMXMAAAXMAMXMAAXXXMMMXMSXMAXMXMAMMMXAXXMSAMXSSMMXXSXSMMSASMSMAMMMAMAAXMSMMMMAXXSXMXAMXAMAS
MAAAXXSAXXAMXMAMXMAMMXMAMXMMMAMAXXMASXMSMXASXXASMMXMXSMMMSMMSMXMASMMSAXMSAMXMSSSSSMXSMSMSAMXSXAAAXXXMAMAMMMMMAMXSAMSSMMSAASXXSASMSASASXSXMAS
MSSSMMSAMSXMXSMMSMMSAMXSMAXSXSMSMSMSAASASXAXXMASXSAMXXAMASAMXMAXMAMASAMSAMXSXAAMAMMXMAMAXXSXSMMXMMXMMSMAMAAMSMSXMMSXAXAMMMXSAXASAMAMMMAMSMXS
XXAXMAMAMMASAAAAMAMXAMAASXSAMXAMAMXAMMSAMMXMXXAMXSMSMSXMASMMASMSMAMMMXMMAMAMMMSMAMSAMMMMMAMAXSMSMSXAMASASMSMMXMAMXMXMMMXSMXMMMMMMMXMXMAMAMAM
SMMMASMSMSAMXSMMSAMSMMMXAMMAMMXMMMXMXXMMMMASXSMSAMMXMXMMMXAMXXAAMASXMAXSAMXSAMXMMSSXSASAMAMAMXXAAXMMSMSXSAXXMASAMASAMXSAAMXMAAASAMMMXSXSAXAM
AAAAAMAXAMXSAXMAMXXXMAMSMXSAMMMMAMMXMSASXSASAAAMMSMSSMMAASMSSMSMSMSASAXSMSMSXXSAMXMASASXXAMMSMSMSMAAMXMMMXMASXSASASXSAMSMMAMASXSASMMAMMSASXS
MMMSMMMMAMAMMXMSMXAAMAMXXXXAXAAXAXMAMMAMXMXSMMMMAAAMMASMXSAAXAXXAASAMSMMAAASMMSASAMXMAMMMMXAAXAAAMXMMAXMASXXMASMMMSAMXMAXSMSAMMSXMAXAXASAMXA
SSMMXAAMAMSXSAAASXMMSMSMSMSMSXXMASMXMMSMSSMSXXAMSMSMSXMMMMMMMMMMMMMAMXXMMMSMAAXMAMSAMXMXASMSSSSSSSMASXXMASMXMMMAAXMXMXMAMAAMMMASAMAXMXAMAXMM
XAASXSSXXMXASMSMSMXMAMAMXAAAMAXSASAMXXMASAMXAMXMAAXAMAAXSAAXXAAMXMSMMMXMASAXMMSMMAMXXAXMXSAXAAAAAAMAMMAXAMXXMXSMMSSMMAMXSMXMASMSAMMXSASXSMAM
SMMMAAAASXMAMXMXXAAMASASMSMSMAXMXMXAMSMMMMXXMMASMSMAMSSMSSSMSMXSAAXMAMXSXSAMSAAAXSMMSASASMXAMXMMMSMSXSAMXAAXXAMAAAMAXASASXMSASASAMAAAXMAMXAM
AXSMMMMMXAMMMASMSSXSASASAAAXMMMSAMXXAAAAAXAMXSXSXMAXAXXMXAMXMAAMMMMSAAAXMMAMMSSSXXAAAAMXXSAMXSXAXMAXAXXMSSMXSASMMMSSMMMAXAXMASAMXMMMSXMXMXMM
MMMAXMXXXMMASASAAAMMMMXMXMMMAAAXAXAXSSSMSAMXAMXSAXSMMXSMMASAMMMXSAAAMMMXAMXMAXMAMXMMSXMXMAMXAASXXSAMXMMXMAMXMAMAAXAAAAMAMSMMAMXMXSAAMXMAXAMS
XAXMMMMSXAAXMAMMMSMMASAXMMASXMMXXAXXXAXMAMSXXSASXMXMSAMXASAMSMAASMSXMASXMMSMSXSASMSMMXAXMXSMSMMXMXSAXMMXSAMXMXMSXMMSXMXSXXAMXMASASMMXAXMSMSA
SSXXAAAMMMMSMSMAMAXSASASMSASAAASXSXSSSMAAAMMMMMSXAAXMASAMMAXSMMXSAMXMAXAMAAAMMMAXAAAMMMMMAXMAAMAMAAXMAAASASXMXAMMXMAMSAMMSMMSMMMASAMSXXXAXXM
MXAXSSXSASASAAMXSMXMASASAMASMMMSAMAMAMXXMSMAMAASXSSSXAMAXMMMSASAMMMAMMSMMSMMSAMAMSSMAAAAMSSMSAMAMMSXSAMMSSMAMSASAXMAMMASAXAAAAXMAMAMAASMSMSX
MMMMXAXSASAMXMMAAMAMXMAMXMXMASXMXMAMAMXXMAMXXMSXMXAXMASXMSAASXMASXSMMAAMXMAASXMXMXAXSSSMXAXMMXXAMXAASXMAMASAMMAAXSMSMMMMXXMSSSMMXXXMMSMAMAMM
XAXSMSMMMMMMMMMSMSMSAMAMAXAMXSAMMSMMXSAXSASXXSMXSMMMSXSAAAMMSAMAMXMAMSXSAMMAMMMXMSSMAMXMMSMMMASXSMMMMSSXSAMXSMSMSMAXMAMASXMAMAMMMSMXMXMXMAMA
MXSXAAAAXAMASMAMMXXMAXAMXSMXASAMAAAXAXXAMAXAMXAAMAAAXMMMMMSAXXMMMMMAMXAMXXXMMASAAXXXMSMXAXAAMAMAAAMAAAMXMAMXSXAXAMMMSMSAAXMASXAAAAAAXAMASASM
MXSMSMSMSXSASMMSAXSXSMSMMMMAASAMSSSMMSSMMMMSSMMMSSMSSMAAAXMMXMSAAMSMSMSMMMSASASAMXSMXMMMAMSMSASMSMMMMMXASMMAMAMSSMSAAAMAMXSAMXXMSSMMSMSASXSM
XASMMMMXXAMASAMMMMSAXAXXAAXXXSAMAMAXAAAXXAAMAMXMXAXXAMSSMSASAAMSXMAAAXAAAMAAMAMAMASAAXXXXXXXMASAAAXXAAAXAMMSMSXMXAMMSSSMXMMASMSMXMXMAXMASAMM
MMSAMAXMMXMAMAMMMAMMMMMSMSSMXSAMMSMMMSSMSMSSXMAMMMMSAMXMASAMMSMXXSMSMSSSMXMSMMXSMXXSASMXSMXAMXMMSSMSMSSMASAMXXASMSMXAAAXAASMSAAMAMSSMSMMMMMA
SAMAMMXAMMMMSAMAMXXAAAXAXAAXAXXMXAXSAAAAXAAMASASAMXMAXAAAMAMAAXMXMAXXXAMXXXXXMAXMSMMSAMXAMASMMAXAAXMAAXMAMXSMSAMAASXMAMMMXMAMMMMASAAXSAMXXXM
MASXMXSSXMAMXMSSSMSSSSSMSMSMMSSSXMAMMSSMMMMSMSAMAMXXASMSSSSMSXSAMMSMSMAMXMASXMASASAMXMSXMSAXAXXMSSMMMMMSSXXXAMMMMMAXXAXXSAMAMAMSXMXXMMSAMXMX
SAMXAMXAXSASMMAAAAXAAAAAXXAAXAXMAMAMMAXXMXXXAMAMSMSMAAAAXXAAAAMXMXAAAXAMSAMSAMXMXMAXSXMXXMASAMXMXAAAAAAMMMMMSMXAMXMASAMXXAXAMAXAMXSSSMXXXAXM
MXMXMMMSMSASAMXSMSMMMSMMMSSSMMSSXMAMSAMSAMXMMMAXAAAMMMMMMSMMMSMXSMMSMXXMSAXSXSAMXSXMAAMSAMXMXSAMAMSSSMMMAAMAXMSMXMXMXAMXMXMXXSMMMMXAASAMSMSA
XMSSMSXXASAMXAMXAAXXAXMAMAMXMXXAXMAXMASAASXMXSMSMSMXAAXMASMAMAMXMAXXAAXMSMMSAMMXMASAMXMAAXMAMMAXXXAMAASXSSSMXMASXSMXSSMMASMSAAXSAMMSMMXMAMAX
MXAAMXAMAMXMMXXMMMXSXMXASAMASXSMXSMMMMMMXMAMAMMAMAAXSSSMSXMAMAXXMSMSSXSAXMAMAMAAXXSMXXSMSMSAAMSMSASMSMMAAAXAASAXMASAXAAXMAAMMMMXAMMAMMXSMSMS
MMSXMMSMAMXMASXMASAMXSMMMAXAXXXMASAXAAAXXSAMXMSASMSMMAAXAMSSSMSSMAAXAAMMMMMSAMXSSMMMSMSAXASMMMAAXAMAXAMXMASMMMXMMMMMSSMMXMMMXSMMSMSAMMAMMAMS
MAXAMAMSAMXMAXASAMASASASMXMSMMXMASASXSXMXSMSMXSXXAMXMMMMMMXAAXAASMSMMMMASXASASAXAASASAMAMAMAXXMMMAMMSAMXMAXMXXAMSXMAAAXMASXMAXMAXAMMSMASXSXS
MASAMAMXMMXMAXXMASXMASAMXSAXASXMMSAMAMMSMMMSMXMASMMAXAAXXAMMMMSXMXAAAASXXMASAMASMMMASMMXMSMXMASXSXXAXAAXMXSSMSMXAAXMSMMXAMAMXSMAMAMAAXXMMXAM
MMXAMSMSAMXMMSMSXMAMXMXMXMAXMMMSAMAMXSAAAAAMAMXAAASMSSMSSMAAXMXASXMXSXSXSSMXMAXMXAMXMAMMMAXAMXAASMMMSSMXSAMXAAMXSXMMAASMSSSMMMMMSXMSSXSAAMAM
ASXXMAASXMAXXAASMSMMMMAMXMSMAMXMASXMAMXSSMSXMMXXSMMMAXAMXXSXSAXMMAXAMAMXAAXXMMMMSSMAXAMSMMSMSMMSMMXAAAAAAAXMSMXXAAMSAMXAXMXAAAAAAAXXAMSMMSAM
ASAMXMXMASASAMMMAAXAAMASAAAMAMXSAMAMXSMMXXMASXMAXAAMXSMASXMXMMXSSSMXMASMXSMXSAMXAASMXSMSAXAAAMXMAXMMMSMSSSMAMAMSSMMAMXMSSMSXMSMSSMMMAXSAMXMM
XMASXXMSMMAXMXXMSMSSXSASMSMXSSMMSSXMMSASXSSMMAAAMSSMMXMXSAMMMXMXAXAASXXMMAMXSASMXMMXAXAXMMMSXSASMMMSAMXAAMAAMAMMAXXSXSMASAAAMXMMAMXSAMXAMSMX
MSAMXAMSXMAMXSMAMXAAMMMMXAXAXAMXAMASASMMAXAASMXXXAMXSAMAMAMAXAMMAMSMXMAMSMMMSMMXSXAASMSMMXXMXMASAAAMAXMMSMSMXAMSXMAMMXMAMMSMMAXSAMXAXMXMMASA
XMAXMSMMAMSAMSMAMMMSMMMSSSSMSAMMMSAMMSXMMMSMMXMSMMSAMAMAXASXSSSMAXAXMMMMAAXASAMAAMSMAAXSMAAAMMMMXMSSSMSAMXAMXSXSASAMXSMSMXXASAMSASXMASAASASX
MSSMMXASXMXMMXMASXAXAXAXAAAASAMMXMASXMXXSAXAMXAXAAMASXSXSXSMAAXXSXMXSAASXSMXSAMXMAASMSMMSSMSAAMAMXXAXAXASMXSAMAMAMASXSAXSASMMXXXXMAMAMMXMXSA
MAMAMSMMAXAMSSSMSMMMAMXMMMMMMXMXXSXXAAAMMMMAMMMSMMSAMXAXAMXMSMSXMAXAXSXSAXMAXAMXXSXAXMAMXMAXXSSMSSMMMMMXMXAMXSAMSMXMXMAMMXMXXMASMXMMASXMMXXM
MAMAMAASXMSAAAAASASAAAXMXXXMAXSXMMMSXMXSASMMMAAAAXXAAMMMSXMMAAXASMMSMMMMMMSSMAMSXMSMXSAMXMAMXXAAAAAMSXMASMMXAMAMXXXSXMAMXASXSASAMXSMMXAAAXSX
SSSSMSMMXAMXMXMMSAMMSXSMSMMXSAMXAAAXMAMSASXSXMSSSMMXMASAMASXSSMMMXAXXAAASXAAMAMXSAAXAMASAMXSXSMMSSMMMASASAXAXSAMXMAAAMSSMASAAMXAMXMASXMMMXAX
XAAMAXSMMSMMMSMMMMMMXAAMAMSAXASXSMXSASXMMMXSXMMMMAXAXMMASAMXAAMXMMMSSXSSSMSMMXAMMSMSXSAMXSXMASXAAAAXSAMXSXMMMAMXMAASXMAAMAMMMASMMMSAMAMSMMMX
MXMMAMAMAAAXSAMMAMAAMMXXMXMASAMMXMAXMMAXMAMMASXSSXSASXSMMMSMMXMAMAMXXAMAXXXSSXASAMXAMXMSXXAMAMMSMSMMMASXMASXXXXMMSAMXMSMMASXMASXAAMASMXAASXM
MMXMXSAMSSSMSAMSASMSSMSASXMAMAMXSXSMAMMASAXMAMAMAAMAMAASAMXXSMSXSMSAMXMXMSMAMSXMASXMMMMMXMXMAXXXAMMMXAXXSAMMMMXMAMAXXXXASXSAXSMMMXSAMXMMSMAS
ASAMXMAXAAAXMAMSASXMAAMAAXMAXAMASAMXAAMASMSMASAMXMMSMMMMMSAXXAMAMAMASAMAMAMAMXXSMMXAAXAXMASMSMAMMMAAMMSXMXXAAXAMMSMMMXSAMAMMMMAAAASMMMMSAMAM
XSMSASMMXSMMMSMMAMXSMXMXSXXSSXMAMAMSMSMAMAAMXMMAXMXAXXXAXMAXMSMXSASMMXSMSASMSMASMASMMXAMSXXAAMAMMSXSAMSXMSSSSSMSAAAAAXMAMSMSASXMMMSAAASMMMSS
AXASMSXMAXMXXASMXMMXXXSAMMXMAMMASMMSAAMAMSMXSAMXSMSMMXMASMXMSAMXSASAAXXASASAAMAMMAXASASXXAMSMSMXMSAMMAMMXAAMMAASMSSMMXMAMXASAXXMSASXMXSAAAXM
SMMMXXXXSSXSXMASMAMMMXMASASMAMSAMAAMMMMXMMAMMSMAAXMXSXSSXMASXASMMMMMMXMMMMMMMMXSMXSAMAMAMXMMMMXAAMMMMAMAMMSMSMMMAMXAXSSMSMMMSMAMSAMXMASMMMSS
MASXSSMAMMAMAXAXMAMAMASXMMSMAMMSMMXSXAMXAMAMAAMMXMASAMXXMMMXMXMAMXSASXASAMXMXSASAMMAMAMAMAMXAASMSMSXMAXMMMMAXMAMAMMMMMAAXXAAAMXMMMMXSAMASAMX
XSMAXAMAXMSMAMMSSSMXSASXMASXMSAMXSMMXMMMMSMMXSSMSSMAMASMMASXSMSAMXSAMSMMXSMMAMMMAMMMSXSASXSSMMSXAASMSMMAAAMMMXMXMXSAASMMMSMSXXAAAMSMMXSAMXSA
XMMMMXSMSMXAMSXMAAAMMAMAMXSMSMMMAMAMXSXMAAAMSMXMAAXXXXMASAXXAASASAMXMMMSAMAMXXXXAMAMSASASAXXXAMXMSMAAAMSMMSMSAAASASAMSAAXXAAXSSSMSASXXMAXSAM
AMASAAMMAMAMXMAMMMMXAAMSAMXXAXXMAXSMAMAMSMSMAASMSSMSAXSMMSSMMMSAMASXSMASMMAMMXSSXSASMAMAMMMSMSSXMAMMMSMMAXMASMSMSAMXMSXMMMSMAXMAMSAMMMSASAMX
XSAMMAXSASASAMAMXXXMMMMMASXSSSMXSXMMMMAMMSMMMXMXMAAAAMXMAXXAXXSMSXMAAMAMXSSMSAAMAMMSMSMSMMAMAAAAASAMAXASXMMXMXAXMXMAXXAXSAMXXAMSMMAMAAXMAXSS
MMASXMASAMAMASXSSMMAXMXSMMAAAAAAMASXSSSSXAMXSAMXSMSMMAAMXXAXMMSAAXMSMMASXXAAMMSMAMSMMAAAMMAMMMSMMMAMXMAMMXSAMXSSMXSMSSSMMASXXAMAXSXSMMSAMXXM
MSMMMSMMAMMMAMAAXAMSMSAMAMXMSMMMSAMAMAMAMASAMXMXMXXMSMMSMMSMSAMAMXMAXSAMXMMMMAXMMMAAXMSMXSAXAXXMXMXMAMSXMASASAMXMASAAMAASXMMSSSSMSAMXMSXXMSX
XAMAAAXXXASASMMMMXMAAMAMMMMMAASXMAMXMMMAMXMASMMAMMMXAMSAMXAAMMMAXAXMMMASAXXASXSASXSSMXAMXSASXSSMSSMMXSMAMASAMXSAMMMMMSSMMSXAXXAAMXMASXMXAAMX
SASMSSSXMAAAXAAXXASXSSSMAAASMSMASMMMSASXSXMXXASMSAMMSXSASMMSMMSSSMSXXXMAXMXASAMAMAXAMXAMAMAMXAAXAAAMMAXXMASXMAMXSSXSXAXAXSMSSMSMMSXASAMXMASM
AXXAMAMMMXMSMSMMXMXAXAMXSMMSXAMMMAAAXASASMSSSMMXSXMAXXXXMMXMAMXAMAAMXMAAASMMMAMSMSAMXXAMXSASMSMMSSMMSASMMASMMXMSMXAMMMSXMXAMXMASXAMXSAMXSASA
AMMMMAMAMMXMAXAMSXMSMSMMMMAXXMSSSMMSSXMXMASAMSAMXMMSSSSMMSAMAMMAMXMSAMAMAXAMMXMXXXMMSSMSXSASAASAMXMAAAMAAXMXSAMSAMXMAXMMSMMMAXAMMMAMSMMXMASM
XMAAMASAMMAMAMAMAMXMAMXAMMAMAXXAMSAMMMMXMXMAMSMSAMXMAXAAASXSAXSAMAXSASASASXMXSSMMMSAAAAXXMMSXXSMMMMSSSMXSSMAMASXAMXSSSXAAAASMMMSAXSAMXMASAMX
MMSSSMSMSMXMASAMMXAMAMMXSXXAASMAMMXMSAMSSXSAMXAAMXXSSSMMMSAMAXMASXMXMSASAAAMMSAAMAMMSMXMXMAXMMXXSXAAAAXXXAMAMXMXXMXMMAMSSMMMXSAAMMXXMMSMSXMX
AXAAMXSAAMXMASXSXMXSAMXXMMMXMXMAMMMMMSAAXMASAMXMASXAXAXMXMXMSMSXMMMXXXAMXMASXSMMMSAMXMASMMXSAASAMMSSSMMMSXMXXMAMXMASXAXAMXSXXMAXMMMSMMAMMASX
SAMAMAMSMMAMXSXMASAMXSXMSASMMXSSSMAXAMMAMXSAMXXXXSAMXMXAAMAXMAMAAASMSXSAMSAMMSMSXMASASMSAXMAMSMAXAXMMXAMMASAXMAMXSASMMXMSASAXSMSMSMAAMXXSAMA
AMXXMMMAXSSSXMMMAMMSMAAASMMAMAMMAMSSXXXAMXMASMAMMMAXAXMSASAXSAMMSMSAMXXAMMMSAXAXXMASAMAXMSXMMXMMMSSMXXMAMSMASMMMMMASASAXMASAXXAAAMSSSMSMMASM
MXMASMSMMXMAXAAXXSXAMMXMSASMMAXXAMXAMMMMMXSAMMAMXSASXSAXMAMXSAMXMXMAMMMAMAAMXMSMASAMMMSMXMAXSXXMAMAXMASMSAMAMXAAASXMAMXXMXMXSAMMSMAXMAAAAAMX
AAAMMAAXMSMMMSSMMMXSSMXXXMMXSASMSSSMAAAAXMMASXXSAXXSMXMXMSMMXSMAXASAMAXXMMMSAMMAXMASMMMAAXSMSAMMSSMMAMAXAAMASMSSXSAMSMMMSMSAXAMAXMSMMSMMMSSX
SXXXMSMXMMASMXMMMAAMAAMSSMMAMMMAMAAMXSXXMAMAMMAMXMAXAXMSMMAMSMMXSMSXSMMAMXXAXMXXXSMMMAMXSXXAXMXMXAXXSXXXSXMXXMMMXMXMAAXSAAMXXAMXMAXAXAAXSMMM
AMMSMMXSASAMMASMMMSXMMMAAAMASAMSMSMMAXXMMSMMAMSMAAMXSXMAXMAMAAMXMMMMAMMMMMSMMMMMMMSASMSAMMMSMXMMSMMMMMMMXMASMSSMSSMSSSMSMSSMMSSSSSSSMMSMXAAS
MAXMAAASXMXSMAMXAAMXSAMSSMMXMAXXAXXMASASAAAMSAMXXSXAAAAMXSASMSMAAAXMASAAAAAAAXAXAAMMSAMASAMASASAAAAAAAAMASAMXAAAAMMAMAAXMAAAMAAXAXAAXAAMSMMS
SSXSMMMSXXASMMSSMXSASAXMMMXSAMXMSMMMSSMMSSSMXMASAAMXSMMXMAXMXXMSSMXSASMSMSSSMSXSMXMMMAMSMXSXSSMSSSXSSSSSMSAXMSMMMSMASMMMMSSMMMSMXMAMMMSXXAMX";
}