# LuduArtsCase
# Interaction System - [Umut KÖK]

> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | 6000,0,58f2 |
| Render Pipeline |  URP |
| Case Süresi | 12 saat |
| Tamamlanma Oranı | %100 |

---

## Kurulum

1. Repository'yi klonlayın:
```bash
git clone https://github.com/[username]/[repo-name].git
```

2. Unity Hub'da projeyi açın
3. `Assets/[ProjectName]/Scenes/TestScene.unity` sahnesini açın
4. Play tuşuna basın

---

## Nasıl Test Edilir

### Kontroller

| Tuş | Aksiyon |
|-----|---------|
| WASD | Hareket |
| Mouse | Bakış yönü |
| E | Etkileşim |
| [Küçük Kutu] = | [Key] |
| [Büyük Kutu] = | [Chest] |
| [Uzun Dikdörtgen] = | [Door] |
| [Kısa Dikdörtgen] = | [Switch] |

### Test Senaryoları

1. **Door Test:**
   - Kapıya yaklaşın, "Press E to Open" mesajını görün
   - E'ye basın, kapı açılsın
   - Tekrar basın, kapı kapansın

2. **Key + Locked Door Test:**
   - Kilitli kapıya yaklaşın, "Locked - Key Required" mesajını görün
   - Anahtarı bulun ve toplayın
   - Kilitli kapıya geri dönün, şimdi açılabilir olmalı

3. **Switch Test:**
   - Switch'e yaklaşın ve aktive edin
   - Bağlı nesnenin (kapı/ışık vb.) tetiklendiğini görün

4. **Chest Test:**
   - Sandığa yaklaşın
   - E'ye basılı tutun, progress bar dolsun
   - Sandık açılsın ve içindeki item alınsın

---

## Mimari Kararlar

### Interaction System Yapısı

Player (Camera)
   ↓ Raycast
InteractionDetector
   ↓ (IInteractable interface)
Interactable Objects
(Door / Chest / Switch)
   ↓
PlayerInventory ——→ UI Controller
        (event)
```
[Mimari diyagram veya açıklama]
```

**Neden bu yapıyı seçtim:**
> Raycast tabanlı, interface-driven modüler bir yapı kurdum. Detector sadece algılama ve input yönetir; etkileşim davranışı objelerin kendisinde kalır. Bu sayede yeni interactable türleri sisteme mevcut kodu değiştirmeden eklenebilir.

**Alternatifler:**
> Başka bir yöntem düşünmedim Raycast i daha önce kullandığım için daha kolay implemente ederim die düşündüm

**Trade-off'lar:**
Avantaj: Modülerlik, genişletilebilirlik, test edilebilirlik.
Dezavantaj: Her frame raycast maliyeti var 

### Kullanılan Design Patterns

Interface / Strategy
IInteractable
Farklı etkileşim türlerini (Instant / Toggle / Hold) ortak sözleşmeyle yönetmek

State (lightweight)
Door / Chest state
Açık-kapalı / kilitli-açık durumlarını state flag’leriyle yönetmek

Observer
Inventory → UI event
Key alındığında UI ikonlarını otomatik güncellemek

---

## Ludu Arts Standartlarına Uyum

### C# Coding Conventions

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| m_ prefix (private fields) | [x] / [] | |
| s_ prefix (private static) | [x] / [] | |
| k_ prefix (private const) | [x] / [] | |
| Region kullanımı | [x] / [ ] | |
| Region sırası doğru | [x] / [ ] | |
| XML documentation | [x] / [ ] | |
| Silent bypass yok | [x] / [ ] | |
| Explicit interface impl. | [x] / [ ] | |

### Naming Convention

| Kural | Uygulandı | Örnekler |
|-------|-----------|----------|
| P_ prefix (Prefab) | [x] / [x]  | P_Door, P_Chest |
| M_ prefix (Material) | [x] / [x]  | M_Door_Wood |
| T_ prefix (Texture) | [x] / [x]  | |
| SO isimlendirme | [x] / [x] | |

### Prefab Kuralları

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| Transform (0,0,0) | [x] / [x] | |
| Pivot bottom-center | [x] / [x] | |
| Collider tercihi | [x] / [ ] | Box > Capsule > Mesh |
| Hierarchy yapısı | [x] / [ ] | |

### Zorlandığım Noktalar
> Yapay zeka kodunu düzeltirken bazı namespaceler kurala uygun sırada olmayabilir veya aynı şekilde fonksiyonlar.

---

## Tamamlanan Özellikler

### Zorunlu (Must Have)

- [x] / [x] Core Interaction System
  - [x] / [x] IInteractable interface
  - [x] / [x] InteractionDetector
  - [x] / [x] Range kontrolü

- [x] / [x] Interaction Types
  - [x] / [x] Instant
  - [x] / [x] Hold
  - [x] / [x] Toggle

- [x] / [x] Interactable Objects
  - [x] / [x] Door (locked/unlocked)
  - [x] / [x] Key Pickup
  - [x] / [x] Switch/Lever
  - [x] / [x] Chest/Container

- [x] / [x] UI Feedback
  - [x] / [x] Interaction prompt
  - [x] / [x] Dynamic text
  - [x] / [x] Hold progress bar
  - [x] / [x] Cannot interact feedback

- [x] / [x] Simple Inventory
  - [x] / [x] Key toplama
  - [x] / [x] UI listesi

### Bonus (Nice to Have)

- [ ] Animation entegrasyonu
- [ ] Sound effects
- [x] Multiple keys / color-coded
- [ ] Interaction highlight
- [ ] Save/Load states
- [x] Chained interactions

---

## Bilinen Limitasyonlar

### Tamamlanamayan Özellikler
Chest açılması için rotate kısmı yetişmedi o yüzden biraz bozuk kaldı

### Bilinen Bug'lar


### İyileştirme Önerileri
1. [Öneri] - [Nasıl daha iyi olabilirdi]
2. [Öneri]

---

## Ekstra Özellikler

Zorunlu gereksinimlerin dışında eklediklerim:

1. **[Özellik Adı]**
   - Açıklama: [Ne yapıyor]
   - Neden ekledim: [Motivasyon]

2. **[Özellik Adı]**
   - ...

---

## Dosya Yapısı

```
Assets/
├── [ProjectName]/
│   ├── Scripts/
│   │   ├── Runtime/
│   │   │   ├── Core/
│   │   │   │   ├── IInteractable.cs
│   │   │   │   └── InteractionDetector.cs
│   │   │   │   └── InteractionType.cs
│   │   │   │   └── ItemData.cs
│   │   │   ├── Interactables/
│   │   │   │   ├── Door.cs
│   │   │   │   ├── Chest.cs
│   │   │   │   ├── Switch.cs
│   │   │   │   ├── Key.cs
│   │   │   ├── Player/
│   │   │   │   └── PlayerController.cs
│   │   │   │   └── PlayerInventory.cs
│   │   │   └── UI/
│   │   │       └── InteractionUIController.cs
│   │   └── Editor/
│   ├── ScriptableObjects/
│   ├── Prefabs/
│   ├── Materials/
│   └── Scenes/
│       └── TestScene.unity
├── Docs/
│   ├── CSharp_Coding_Conventions.md
│   ├── Naming_Convention_Kilavuzu.md
│   └── Prefab_Asset_Kurallari.md
├── README.md
├── PROMPTS.md
└── .gitignore
```

---

## İletişim

| Bilgi | Değer |
|-------|-------|
| Ad Soyad | [Umut KÖK] |
| E-posta | [umutkok88@gmail.com] |
| LinkedIn | [profil linki] |
| GitHub | [github.com/username] |

---

*Bu proje Ludu Arts Unity Developer Intern Case için hazırlanmıştır.*
