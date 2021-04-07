# Video-Conference App 📷 ⟷ 📞
VideoChat napisany na platfromie Windows Forms. Realizowany za pomocą UDP protokołu, przedstawia Peer-to-Peer czat gdzie dwie osoby znajdujące się w sieci lokalnej mogą połączyć się między sobą, widzieć oraz slyszeć swojego partnera.
## Realizacja etapów 
0️⃣ Uwierzyć że da się to zrobić na niskim poziomie programowania za pomocą socketów [✅]  
1️⃣ Napisać half-duplex wysyłanie wideo, czyli jedna strona tylko odbiera druga tylko wysyła w jednym czasie [✅]  
2️⃣ Fragmentacja datagramu UDP, w przypadku gdy rodzielczość kamery jest zbyt wysoka żeby wysłać jednym pakietem UDP [✅]  
3️⃣ Realizować full-duplex przesyłanie wideo [✅]  
4️⃣ Zrobić menu wyboru portów przesyłania audio/wideo oraz wybór kamery [✅]  
5️⃣ Zrobić interfejs w stylu Dark Metro [✅]  
6️⃣ Realizacja half-duplex wysyłanie audio, czyli jedna strona tylko odbiera druga tylko wysyła w jednym czasie [✅]  
7️⃣ Realizacja full-duplex wysyłania audio [✅]  
8️⃣ Przerobienie z wersji surowej do wersji obiektowej [✅]    
9️⃣ Realizacja wyłączania mikrofonu oraz kamerki [✅]  
1️⃣0️⃣ Sprawdzanie wpisanych adresów oraz portów [✅]  
1️⃣1️⃣ Przetestowanie kompletnego programu [✅]
## Wykorzystane biblioteki
- [NAudio](https://github.com/naudio/NAudio) - nagrywanie głosu z mikrofonu
- [AForge](http://www.aforgenet.com/framework/) - nagrywanie wideo z kamery
## Questions and Answers
**Q**: Program wypisuje błąd w miejscu inicjalizacji przychodzącego audio strumienia:
```c#
  outputAudio = new WaveOut();
  outputAudio.Init(bufferStream);
```
> Wynika z tego powodu że biblioteka ```NAudio``` wymaga co najmniej ```.NET Framework 4.7.2``` więc jeżeli jest taki problem, należy pobrać nowy framework i skompilować.  

**Q**: Program nie może się skompilować bo brakuje biblioteki netstandard v2.0.0.0  
> Rozwiązanie jest w tym że wchodzimy do pliku name.**csproj** i wpisujemy ```<Reference Include="netstandard"/>``` 
## Przykładowe uruchomienie
Aby przetestować działanie programu potrzebujecie 2 komputery w sieci lokalnej. Jeżeli nie macie dwóch komputerów możliwy też sposób gdy macie na jednym komputerze 2 kamery(np. jedna z nich wbudowana, druga podłączona za pomocą USB). Przykładowa konfiguracja w przypadku uruchomienia dwóch klientów na jednym komputerze:  
| Parametry     | PC — 1             | PC — 2    |
| ------------- |:------------------:|:---------:|
| IP Address    | 127.0.0.1          | 127.0.0.1 |
| Local Video   | 7777               | 7778      |
| Remote Video  | 7778               | 7777      |
| Local Audio   | 5555               | 5556      |
| Remote Audio  | 5556               | 5555      |
## Screenshoty
![second](https://user-images.githubusercontent.com/19534189/113905627-a3fb9680-97d3-11eb-9ce2-c0ab30bd0a01.png)
![first](https://user-images.githubusercontent.com/19534189/113905630-a4942d00-97d3-11eb-8941-babf3bdd99b2.png)
![Screenshot_1](https://user-images.githubusercontent.com/19534189/113905624-a2ca6980-97d3-11eb-8b59-f1a4a86f3d7d.png)
