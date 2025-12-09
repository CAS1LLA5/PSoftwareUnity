🚀 Descripción
PSoftwareUnity es un videojuego 2D de acción y plataformas que desarrollamos como proyecto integrador. Incluye mecánicas completas de movimiento, combate, sistema de puntaje, múltiples niveles y UI profesional. ¡Juega, salta, derrota enemigos y alcanza la victoria!

Equipo de desarrollo:

👨‍💻 Luis Casillas

👨‍💻 Eric Daniel

👨‍💻 Israel Garcia

👩‍💻 Guadalupe Rojo

✨ Características Principales
🎮 Control fluido del personaje (mover, saltar, atacar)

👾 IA de enemigos con patrulla y persecución

⭐ Sistema de puntaje y coleccionables

📱 UI completa (menús, HUD, game over)

🔊 Efectos de sonido y música inmersiva

🎯 5 escenas (MainMenu, Level1, Level2, Victory, GameOver)

⚡ 60 FPS optimizado

🛠️ Tecnologías Utilizadas
Frontend	Backend	Herramientas
Unity 2D	C# Scripts	Git/GitHub
Sprite Renderer	Rigidbody2D	Visual Studio
Canvas UI	Physics 2D	Aseprite/GIMP
📁 Estructura del Proyecto
text
PSoftwareUnity/
├── Assets/
│   ├── Scenes/          # MainMenu.unity, Level_1.unity, Level_2.unity
│   ├── Scripts/         # PlayerController.cs, EnemyController.cs
│   ├── Sprites/         # Personaje, enemigos, fondos
│   ├── Audio/           # SFX y música
│   └── Prefabs/         # Objetos reutilizables
├── ProjectSettings/
└── README.md
🎮 Cómo Jugar
Requisitos
Unity 2021 LTS o superior

Windows/Mac/Linux

Instrucciones
Clona el repositorio:

bash
git clone https://github.com/CAS1LLA5/PSoftwareUnity.git
Abre en Unity:

text
File → Open Folder → Selecciona la carpeta PSoftwareUnity
Ejecuta:

text
Play Button (▶️) en Unity Editor
Controles
Acción	Tecla
Mover Izquierda	A / ←
Mover Derecha	D / →
Saltar	SPACE
Atacar	J
Pausa	ESC
📋 Componentes Principales
PlayerController.cs
csharp
// Movimiento, salto, colisiones y animaciones
public class PlayerController : MonoBehaviour {
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    // ... lógica completa de jugador
}
GameManager.cs (Singleton)
csharp
// Gestión global: vidas, puntaje, escenas, pausa
public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public int score = 0;
    public int lives = 3;
}
🧪 Instalación Rápida
bash
# 1. Clonar
git clone https://github.com/CAS1LLA5/PSoftwareUnity.git

# 2. Abrir en Unity Hub
# Unity Hub → Add → Seleccionar carpeta

# 3. Play! 🎮
📈 Roadmap
✅ MVP completo (jugable)

✅ Múltiples niveles

✅ UI profesional

🔄 Sistema de guardado (Próximo)

🔄 Móvil support (Próximo)

🔄 Leaderboards (Próximo)

📊 Demo
![WhatsApp Image 2025-12-09 at 11 49 21 AM](https://github.com/user-attachments/assets/3c920202-ae61-47a5-9081-293428eef8b1)


🤝 Contribuir
Fork el proyecto

Crea tu branch (git checkout -b feature/nueva-funcionalidad)

Commit tus cambios (git commit -m 'Agrega nueva funcionalidad')

Push a la branch (git push origin feature/nueva-funcionalidad)

Abre un Pull Request

📄 Licencia
Este proyecto está bajo la Licencia Académica - ver LICENSE para más detalles.

📞 Contacto
Repositorio oficial: CAS1LLA5/PSoftwareUnity

¡Gracias por tu interés! ⭐
