<!DOCTYPE html>
<html lang="es">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Artecnología+ | Aprende programación creativa</title>
  <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700&family=Press+Start+2P&display=swap" rel="stylesheet">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">
  <style>
    :root {
      --primary: #6a5acd;
      --secondary: #ff7f50;
      --accent: #20b2aa;
      --dark: #2f4f4f;
      --light: #f8f8ff;
      --success: #3cb371;
      --warning: #ffa500;
      --danger: #ff4500;
    }
    
    * {
      box-sizing: border-box;
      margin: 0;
      padding: 0;
    }
    
    body {
      font-family: 'Roboto', sans-serif;
      background-color: #f5f5f5;
      color: #333;
      line-height: 1.6;
      overflow-x: hidden;
    }
    
    /* Header estilizado */
    header {
      background: linear-gradient(135deg, var(--primary), var(--accent));
      color: white;
      padding: 1rem 2rem;
      box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
      display: flex;
      justify-content: space-between;
      align-items: center;
      position: relative;
      z-index: 10;
    }
    
    .logo {
      display: flex;
      align-items: center;
      gap: 15px;
    }
    
    .logo h1 {
      font-family: 'Press Start 2P', cursive;
      font-size: 1.8rem;
      text-shadow: 3px 3px 0 rgba(0, 0, 0, 0.2);
      margin: 0;
    }
    
    .logo i {
      font-size: 2rem;
      animation: pulse 2s infinite;
    }
    
    @keyframes pulse {
      0% { transform: scale(1); }
      50% { transform: scale(1.1); }
      100% { transform: scale(1); }
    }
    
    .user-actions {
      display: flex;
      gap: 15px;
    }
    
    .btn {
      padding: 0.6rem 1.2rem;
      border: none;
      border-radius: 50px;
      font-weight: 500;
      cursor: pointer;
      transition: all 0.3s ease;
      display: inline-flex;
      align-items: center;
      gap: 8px;
    }
    
    .btn-primary {
      background-color: var(--primary);
      color: white;
    }
    
    .btn-outline {
      background: transparent;
      border: 2px solid white;
      color: white;
    }
    
    .btn:hover {
      transform: translateY(-2px);
      box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
    }
    
    /* Contenedor principal */
    .main-container {
      display: flex;
      min-height: calc(100vh - 70px);
    }
    
    /* Panel izquierdo - Sprites y herramientas */
    .left-panel {
      width: 280px;
      background: white;
      border-right: 1px solid #ddd;
      padding: 1rem;
      display: flex;
      flex-direction: column;
      box-shadow: 2px 0 10px rgba(0, 0, 0, 0.05);
      transition: all 0.3s ease;
    }
    
    .panel-header {
      display: flex;
      justify-content: space-between;
      align-items: center;
      margin-bottom: 1rem;
      padding-bottom: 0.5rem;
      border-bottom: 1px solid #eee;
    }
    
    .panel-header h3 {
      font-size: 1.2rem;
      color: var(--dark);
    }
    
    .add-btn {
      background: var(--accent);
      color: white;
      border: none;
      width: 30px;
      height: 30px;
      border-radius: 50%;
      display: flex;
      align-items: center;
      justify-content: center;
      cursor: pointer;
      transition: all 0.3s;
    }
    
    .add-btn:hover {
      background: var(--primary);
      transform: rotate(90deg);
    }
    
    /* Lista de sprites */
    #sprites-list {
      flex-grow: 1;
      overflow-y: auto;
    }
    
    .sprite-item {
      background: white;
      border: 2px solid #eee;
      border-radius: 8px;
      padding: 0.8rem;
      margin-bottom: 0.8rem;
      cursor: pointer;
      transition: all 0.3s;
      display: flex;
      align-items: center;
      gap: 10px;
    }
    
    .sprite-item:hover {
      border-color: var(--accent);
      transform: translateX(5px);
    }
    
    .sprite-item.active {
      border-color: var(--primary);
      background-color: #f0f8ff;
    }
    
    .sprite-preview {
      width: 40px;
      height: 40px;
      border-radius: 4px;
      background-color: var(--secondary);
      display: flex;
      align-items: center;
      justify-content: center;
      color: white;
      font-size: 1.2rem;
    }
    
    .sprite-info {
      flex-grow: 1;
    }
    
    .sprite-name {
      font-weight: 500;
      margin-bottom: 0.2rem;
    }
    
    .sprite-actions {
      display: flex;
      gap: 5px;
    }
    
    .sprite-btn {
      background: none;
      border: none;
      color: #777;
      cursor: pointer;
      transition: all 0.2s;
    }
    
    .sprite-btn:hover {
      color: var(--primary);
    }
    
    /* Editor Blockly */
    #blockly-container {
      flex-grow: 1;
      position: relative;
      background: #f9f9f9;
    }
    
    #blocklyDiv {
      position: absolute;
      top: 0;
      left: 0;
      right: 0;
      bottom: 0;
    }
    
    /* Panel derecho - Escenario y controles */
    .right-panel {
      width: 350px;
      background: white;
      border-left: 1px solid #ddd;
      padding: 1rem;
      display: flex;
      flex-direction: column;
      box-shadow: -2px 0 10px rgba(0, 0, 0, 0.05);
    }
    
    /* Escenario */
    #stage-container {
      position: relative;
      width: 100%;
      height: 250px;
      background: white;
      border: 2px solid #ddd;
      border-radius: 8px;
      overflow: hidden;
      margin-bottom: 1rem;
      box-shadow: inset 0 0 10px rgba(0, 0, 0, 0.05);
    }
    
    #stage {
      width: 100%;
      height: 100%;
      background: linear-gradient(45deg, #f5f7fa 25%, transparent 25%), 
                  linear-gradient(-45deg, #f5f7fa 25%, transparent 25%), 
                  linear-gradient(45deg, transparent 75%, #f5f7fa 75%), 
                  linear-gradient(-45deg, transparent 75%, #f5f7fa 75%);
      background-size: 20px 20px;
      background-position: 0 0, 0 10px, 10px -10px, -10px 0px;
    }
    
    .sprite-display {
      position: absolute;
      width: 40px;
      height: 40px;
      background-color: var(--secondary);
      border-radius: 4px;
      display: flex;
      align-items: center;
      justify-content: center;
      color: white;
      font-size: 1.2rem;
      transition: all 0.3s;
      user-select: none;
    }
    
    /* Controles */
    .controls {
      display: flex;
      gap: 10px;
      margin-bottom: 1rem;
    }
    
    .control-btn {
      flex: 1;
      padding: 0.6rem;
      border: none;
      border-radius: 6px;
      font-weight: 500;
      cursor: pointer;
      transition: all 0.3s;
      display: flex;
      align-items: center;
      justify-content: center;
      gap: 8px;
    }
    
    .run-btn {
      background-color: var(--success);
      color: white;
    }
    
    .stop-btn {
      background-color: var(--danger);
      color: white;
    }
    
    .reset-btn {
      background-color: var(--warning);
      color: white;
    }
    
    /* Propiedades del sprite */
    .properties-panel {
      margin-top: 1rem;
      padding: 1rem;
      background: #f9f9f9;
      border-radius: 8px;
    }
    
    .property-group {
      margin-bottom: 1rem;
    }
    
    .property-group h4 {
      margin-bottom: 0.5rem;
      color: var(--dark);
    }
    
    .property-row {
      display: flex;
      align-items: center;
      margin-bottom: 0.5rem;
    }
    
    .property-label {
      width: 80px;
      font-size: 0.9rem;
      color: #666;
    }
    
    .property-value {
      flex-grow: 1;
    }
    
    input[type="range"], input[type="text"] {
      width: 100%;
      padding: 0.3rem;
      border: 1px solid #ddd;
      border-radius: 4px;
    }
    
    /* Pestañas */
    .tabs {
      display: flex;
      border-bottom: 1px solid #ddd;
      margin-bottom: 1rem;
    }
    
    .tab {
      padding: 0.5rem 1rem;
      cursor: pointer;
      border-bottom: 3px solid transparent;
      transition: all 0.3s;
    }
    
    .tab.active {
      border-bottom-color: var(--primary);
      color: var(--primary);
      font-weight: 500;
    }
    
    .tab-content {
      display: none;
    }
    
    .tab-content.active {
      display: block;
    }
    
    /* Consola de salida */
    #output-console {
      flex-grow: 1;
      background: #1e1e1e;
      color: #d4d4d4;
      padding: 0.8rem;
      border-radius: 6px;
      font-family: 'Courier New', monospace;
      font-size: 0.9rem;
      overflow-y: auto;
      max-height: 150px;
      margin-top: auto;
    }
    
    .console-message {
      margin-bottom: 0.3rem;
    }
    
    .console-error {
      color: #f48771;
    }
    
    .console-success {
      color: #4ec9b0;
    }
    
    /* Responsive */
    @media (max-width: 1200px) {
      .left-panel {
        width: 240px;
      }
      .right-panel {
        width: 300px;
      }
    }
    
    @media (max-width: 992px) {
      .main-container {
        flex-direction: column;
      }
      .left-panel {
        width: 100%;
        border-right: none;
        border-bottom: 1px solid #ddd;
      }
      #blockly-container {
        height: 500px;
      }
      .right-panel {
        width: 100%;
        border-left: none;
        border-top: 1px solid #ddd;
      }
    }
    
    /* Animaciones */
    @keyframes fadeIn {
      from { opacity: 0; transform: translateY(10px); }
      to { opacity: 1; transform: translateY(0); }
    }
    
    .animate-in {
      animation: fadeIn 0.3s ease-out forwards;
    }
  </style>
  
  <!-- Blockly + español -->
  <script src="https://unpkg.com/blockly/blockly.min.js"></script>
  <script src="https://unpkg.com/blockly/msg/es.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/interactjs/dist/interact.min.js"></script>
</head>
<body>
  <header>
    <div class="logo">
      <i class="fas fa-robot"></i>
      <h1>Artecnología+</h1>
    </div>
    <div class="user-actions">
      <button class="btn btn-outline">
        <i class="fas fa-save"></i> Guardar
      </button>
      <button class="btn btn-primary">
        <i class="fas fa-share-alt"></i> Compartir
      </button>
    </div>
  </header>

  <div class="main-container">
    <!-- Panel izquierdo - Sprites y herramientas -->
    <div class="left-panel">
      <div class="panel-header">
        <h3>Sprites</h3>
        <button class="add-btn" id="add-sprite-btn">
          <i class="fas fa-plus"></i>
        </button>
      </div>
      
      <div id="sprites-list">
        <!-- Sprites se añadirán dinámicamente -->
      </div>
      
      <div class="properties-panel">
        <h4>Herramientas</h4>
        <div class="controls" style="justify-content: center;">
          <button class="control-btn" id="clear-btn">
            <i class="fas fa-broom"></i> Limpiar
          </button>
        </div>
      </div>
    </div>

    <!-- Área de Blockly -->
    <div id="blockly-container">
      <div id="blocklyDiv"></div>
    </div>

    <!-- Panel derecho - Escenario y controles -->
    <div class="right-panel">
      <div class="tabs">
        <div class="tab active" data-tab="stage">Escenario</div>
        <div class="tab" data-tab="properties">Propiedades</div>
        <div class="tab" data-tab="assets">Recursos</div>
      </div>
      
      <div class="tab-content active" id="stage-tab">
        <div id="stage-container">
          <div id="stage"></div>
          <!-- Sprites aparecerán aquí -->
        </div>
        
        <div class="controls">
          <button class="control-btn run-btn" id="run-button">
            <i class="fas fa-play"></i> Ejecutar
          </button>
          <button class="control-btn stop-btn" id="stop-button">
            <i class="fas fa-stop"></i> Detener
          </button>
          <button class="control-btn reset-btn" id="reset-button">
            <i class="fas fa-undo"></i> Reiniciar
          </button>
        </div>
      </div>
      
      <div class="tab-content" id="properties-tab">
        <div class="properties-panel">
          <h4>Propiedades del Sprite</h4>
          <div class="property-group">
            <div class="property-row">
              <span class="property-label">Nombre:</span>
              <div class="property-value">
                <input type="text" id="sprite-name-input" placeholder="Nombre del sprite">
              </div>
            </div>
            <div class="property-row">
              <span class="property-label">Posición X:</span>
              <div class="property-value">
                <input type="range" id="sprite-x-input" min="-200" max="200" value="0">
                <span id="sprite-x-value">0</span>
              </div>
            </div>
            <div class="property-row">
              <span class="property-label">Posición Y:</span>
              <div class="property-value">
                <input type="range" id="sprite-y-input" min="-150" max="150" value="0">
                <span id="sprite-y-value">0</span>
              </div>
            </div>
            <div class="property-row">
              <span class="property-label">Tamaño:</span>
              <div class="property-value">
                <input type="range" id="sprite-size-input" min="20" max="150" value="40">
                <span id="sprite-size-value">40</span>%
              </div>
            </div>
            <div class="property-row">
              <span class="property-label">Rotación:</span>
              <div class="property-value">
                <input type="range" id="sprite-rotation-input" min="0" max="360" value="0">
                <span id="sprite-rotation-value">0</span>°
              </div>
            </div>
          </div>
          <div class="property-group">
            <h4>Apariencia</h4>
            <div class="controls" style="justify-content: space-between;">
              <button class="control-btn" id="color-btn" style="background: #6a5acd; color: white;">
                <i class="fas fa-palette"></i> Color
              </button>
              <button class="control-btn" id="costume-btn" style="background: #20b2aa; color: white;">
                <i class="fas fa-image"></i> Disfraz
              </button>
            </div>
          </div>
        </div>
      </div>
      
      <div class="tab-content" id="assets-tab">
        <div class="properties-panel">
          <h4>Biblioteca de Recursos</h4>
          <p>Selecciona sprites y fondos para tu proyecto.</p>
          <!-- Aquí iría la biblioteca de recursos -->
        </div>
      </div>
      
      <div id="output-console">
        <div class="console-message console-success">Bienvenido a Artecnología+</div>
        <div class="console-message">Listo para programar...</div>
      </div>
    </div>
  </div>

  <!-- Toolbox XML para Blockly mejorado -->
 <!-- Toolbox XML para Blockly corregido -->
<xml xmlns="https://developers.google.com/blockly/xml" id="toolbox" style="display: none">
  <category name="Movimiento" colour="#6A5ACD">
    <block type="motion_movesteps">
      <value name="STEPS">
        <shadow type="math_number">
          <field name="NUM">10</field>
        </shadow>
      </value>
    </block>
    <block type="motion_turnright">
      <value name="DEGREES">
        <shadow type="math_number">
          <field name="NUM">15</field>
        </shadow>
      </value>
    </block>
    <block type="motion_turnleft">
      <value name="DEGREES">
        <shadow type="math_number">
          <field name="NUM">15</field>
        </shadow>
      </value>
    </block>
    <block type="motion_gotoxy">
      <value name="X">
        <shadow type="math_number">
          <field name="NUM">0</field>
        </shadow>
      </value>
      <value name="Y">
        <shadow type="math_number">
          <field name="NUM">0</field>
        </shadow>
      </value>
    </block>
    <block type="motion_changex">
      <value name="DX">
        <shadow type="math_number">
          <field name="NUM">10</field>
        </shadow>
      </value>
    </block>
    <block type="motion_changey">
      <value name="DY">
        <shadow type="math_number">
          <field name="NUM">10</field>
        </shadow>
      </value>
    </block>
    <block type="motion_setrotation">
      <value name="DEGREES">
        <shadow type="math_number">
          <field name="NUM">90</field>
        </shadow>
      </value>
    </block>
  </category>

  <category name="Apariencia" colour="#20B2AA">
    <block type="looks_say">
      <value name="TEXT">
        <shadow type="text">
          <field name="TEXT">¡Hola!</field>
        </shadow>
      </value>
    </block>
    <block type="looks_changecolor">
      <value name="COLOR">
        <shadow type="colour_picker">
          <field name="COLOUR">#ff0000</field>
        </shadow>
      </value>
    </block>
    <block type="looks_setsize">
      <value name="SIZE">
        <shadow type="math_number">
          <field name="NUM">100</field>
        </shadow>
      </value>
    </block>
    <block type="looks_show"></block>
    <block type="looks_hide"></block>
  </category>

  <category name="Eventos" colour="#FFBF00">
    <block type="event_whenflagclicked"></block>
    <block type="event_whenkeypressed">
      <field name="KEY">space</field>
    </block>
    <block type="event_whenthisspriteclicked"></block>
    <block type="event_whenbackdropswitchesto">
      <field name="BACKDROP">backdrop1</field>
    </block>
  </category>

  <category name="Control" colour="#FF8C1A">
    <block type="controls_repeat">
      <value name="TIMES">
        <shadow type="math_number">
          <field name="NUM">10</field>
        </shadow>
      </value>
    </block>
    <block type="controls_forever"></block>
    <block type="controls_if"></block>
    <block type="controls_if_else"></block>
    <block type="controls_wait">
      <value name="DURATION">
        <shadow type="math_number">
          <field name="NUM">1</field>
        </shadow>
      </value>
    </block>
  </category>

  <category name="Sensores" colour="#4CAF50">
    <block type="sensing_touchingobject">
      <field name="OBJECT">_mouse_</field>
    </block>
    <block type="sensing_keypressed">
      <field name="KEY">space</field>
    </block>
    <block type="sensing_mousedown"></block>
    <block type="sensing_mousex"></block>
    <block type="sensing_mousey"></block>
  </category>

  <category name="Operadores" colour="#5C6BC0">
    <block type="math_number">
      <field name="NUM">0</field>
    </block>
    <block type="math_arithmetic">
      <value name="A">
        <shadow type="math_number">
          <field name="NUM">1</field>
        </shadow>
      </value>
      <value name="B">
        <shadow type="math_number">
          <field name="NUM">1</field>
        </shadow>
      </value>
    </block>
    <block type="math_random">
      <value name="FROM">
        <shadow type="math_number">
          <field name="NUM">1</field>
        </shadow>
      </value>
      <value name="TO">
        <shadow type="math_number">
          <field name="NUM">10</field>
        </shadow>
      </value>
    </block>
    <block type="logic_compare"></block>
    <block type="logic_operation"></block>
    <block type="logic_boolean"></block>
  </category>

  <category name="Variables" colour="#FF7043" custom="VARIABLE"></category>
  <category name="Funciones" colour="#BA68C8" custom="PROCEDURE"></category>
</xml>

  <script>
    // Definición de bloques personalizados adicionales
    Blockly.defineBlocksWithJsonArray([
      {
        "type": "motion_changex",
        "message0": "cambiar x por %1",
        "args0": [
          {
            "type": "input_value",
            "name": "DX",
            "check": "Number"
          }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": "#6A5ACD",
        "tooltip": "Cambia la posición horizontal del sprite"
      },
      {
        "type": "motion_changey",
        "message0": "cambiar y por %1",
        "args0": [
          {
            "type": "input_value",
            "name": "DY",
            "check": "Number"
          }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": "#6A5ACD",
        "tooltip": "Cambia la posición vertical del sprite"
      },
      {
        "type": "motion_setrotation",
        "message0": "apuntar en dirección %1 grados",
        "args0": [
          {
            "type": "input_value",
            "name": "DEGREES",
            "check": "Number"
          }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": "#6A5ACD",
        "tooltip": "Establece la rotación del sprite"
      },
      {
        "type": "looks_say",
        "message0": "decir %1",
        "args0": [
          {
            "type": "input_value",
            "name": "TEXT",
            "check": "String"
          }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": "#20B2AA",
        "tooltip": "Muestra un mensaje en la pantalla"
      },
      {
        "type": "looks_changecolor",
        "message0": "cambiar color por %1",
        "args0": [
          {
            "type": "input_value",
            "name": "COLOR",
            "check": "Colour"
          }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": "#20B2AA",
        "tooltip": "Cambia el color del sprite"
      },
      {
        "type": "looks_setsize",
        "message0": "fijar tamaño a %1%",
        "args0": [
          {
            "type": "input_value",
            "name": "SIZE",
            "check": "Number"
          }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": "#20B2AA",
        "tooltip": "Establece el tamaño del sprite"
      },
      {
        "type": "looks_show",
        "message0": "mostrar",
        "previousStatement": null,
        "nextStatement": null,
        "colour": "#20B2AA",
        "tooltip": "Muestra el sprite"
      },
      {
        "type": "looks_hide",
        "message0": "ocultar",
        "previousStatement": null,
        "nextStatement": null,
        "colour": "#20B2AA",
        "tooltip": "Oculta el sprite"
      },
      {
        "type": "event_whenthisspriteclicked",
        "message0": "al hacer clic en este sprite",
        "nextStatement": null,
        "colour": "#FFBF00",
        "tooltip": "Se ejecuta cuando se hace clic en este sprite"
      },
      {
        "type": "event_whenbackdropswitchesto",
        "message0": "al cambiar a fondo %1",
        "args0": [
          {
            "type": "field_dropdown",
            "name": "BACKDROP",
            "options": [
              ["fondo 1", "backdrop1"],
              ["fondo 2", "backdrop2"]
            ]
          }
        ],
        "nextStatement": null,
        "colour": "#FFBF00",
        "tooltip": "Se ejecuta cuando cambia el fondo"
      },
      {
        "type": "controls_forever",
        "message0": "por siempre",
        "message1": "hacer %1",
        "args1": [
          {
            "type": "input_statement",
            "name": "DO"
          }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": "#FF8C1A",
        "tooltip": "Repite los bloques internos indefinidamente"
      },
      {
        "type": "controls_if_else",
        "message0": "si %1 entonces",
        "args0": [
          {
            "type": "input_value",
            "name": "IF0",
            "check": "Boolean"
          }
        ],
        "message1": "hacer %1",
        "args1": [
          {
            "type": "input_statement",
            "name": "DO0"
          }
        ],
        "message2": "si no",
        "message3": "hacer %1",
        "args3": [
          {
            "type": "input_statement",
            "name": "DO1"
          }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": "#FF8C1A",
        "tooltip": "Si la condición es verdadera, ejecuta los primeros bloques, si no, los segundos"
      },
      {
        "type": "controls_wait",
        "message0": "esperar %1 segundos",
        "args0": [
          {
            "type": "input_value",
            "name": "DURATION",
            "check": "Number"
          }
        ],
        "previousStatement": null,
        "nextStatement": null,
        "colour": "#FF8C1A",
        "tooltip": "Espera el tiempo especificado"
      },
      {
        "type": "sensing_touchingobject",
        "message0": "tocando %1",
        "args0": [
          {
            "type": "field_dropdown",
            "name": "OBJECT",
            "options": [
              ["el ratón", "_mouse_"],
              ["borde", "_edge_"],
              ["sprite 1", "sprite1"],
              ["sprite 2", "sprite2"]
            ]
          }
        ],
        "output": "Boolean",
        "colour": "#4CAF50",
        "tooltip": "Devuelve verdadero si el sprite está tocando el objeto especificado"
      },
      {
        "type": "sensing_keypressed",
        "message0": "tecla %1 presionada?",
        "args0": [
          {
            "type": "field_dropdown",
            "name": "KEY",
            "options": [
              ["espacio", "space"],
              ["flecha arriba", "up"],
              ["flecha abajo", "down"],
              ["flecha izquierda", "left"],
              ["flecha derecha", "right"]
            ]
          }
        ],
        "output": "Boolean",
        "colour": "#4CAF50",
        "tooltip": "Devuelve verdadero si la tecla especificada está presionada"
      },
      {
        "type": "sensing_mousedown",
        "message0": "ratón presionado?",
        "output": "Boolean",
        "colour": "#4CAF50",
        "tooltip": "Devuelve verdadero si el botón del ratón está presionado"
      },
      {
        "type": "sensing_mousex",
        "message0": "posición x del ratón",
        "output": "Number",
        "colour": "#4CAF50",
        "tooltip": "Devuelve la posición horizontal del ratón"
      },
      {
        "type": "sensing_mousey",
        "message0": "posición y del ratón",
        "output": "Number",
        "colour": "#4CAF50",
        "tooltip": "Devuelve la posición vertical del ratón"
      }
    ]);

    // Generadores de código JavaScript para los nuevos bloques
    Blockly.JavaScript['motion_changex'] = function(block) {
      const dx = Blockly.JavaScript.valueToCode(block, 'DX', Blockly.JavaScript.ORDER_ATOMIC) || '0';
      return 'changeX(' + dx + ');\n';
    };

    Blockly.JavaScript['motion_changey'] = function(block) {
      const dy = Blockly.JavaScript.valueToCode(block, 'DY', Blockly.JavaScript.ORDER_ATOMIC) || '0';
      return 'changeY(' + dy + ');\n';
    };

    Blockly.JavaScript['motion_setrotation'] = function(block) {
      const degrees = Blockly.JavaScript.valueToCode(block, 'DEGREES', Blockly.JavaScript.ORDER_ATOMIC) || '0';
      return 'setRotation(' + degrees + ');\n';
    };

    Blockly.JavaScript['looks_say'] = function(block) {
      const text = Blockly.JavaScript.valueToCode(block, 'TEXT', Blockly.JavaScript.ORDER_ATOMIC) || "''";
      return 'say(' + text + ');\n';
    };

    Blockly.JavaScript['looks_changecolor'] = function(block) {
      const color = Blockly.JavaScript.valueToCode(block, 'COLOR', Blockly.JavaScript.ORDER_ATOMIC) || "'#000000'";
      return 'changeColor(' + color + ');\n';
    };

    Blockly.JavaScript['looks_setsize'] = function(block) {
      const size = Blockly.JavaScript.valueToCode(block, 'SIZE', Blockly.JavaScript.ORDER_ATOMIC) || '100';
      return 'setSize(' + size + ');\n';
    };

    Blockly.JavaScript['looks_show'] = function(block) {
      return 'showSprite();\n';
    };

    Blockly.JavaScript['looks_hide'] = function(block) {
      return 'hideSprite();\n';
    };

    Blockly.JavaScript['event_whenthisspriteclicked'] = function(block) {
      const branch = Blockly.JavaScript.statementToCode(block, 'STACK');
      return 'function whenThisSpriteClicked() {\n' + branch + '};\n';
    };

    Blockly.JavaScript['event_whenbackdropswitchesto'] = function(block) {
      const backdrop = block.getFieldValue('BACKDROP');
      const branch = Blockly.JavaScript.statementToCode(block, 'STACK');
      return 'function whenBackdropSwitchesTo' + backdrop + '() {\n' + branch + '};\n';
    };

    Blockly.JavaScript['controls_forever'] = function(block) {
      const branch = Blockly.JavaScript.statementToCode(block, 'DO');
      return 'while (true) {\n' + branch + '}\n';
    };

    Blockly.JavaScript['controls_if_else'] = function(block) {
      const condition = Blockly.JavaScript.valueToCode(block, 'IF0', Blockly.JavaScript.ORDER_ATOMIC) || 'false';
      const branch1 = Blockly.JavaScript.statementToCode(block, 'DO0');
      const branch2 = Blockly.JavaScript.statementToCode(block, 'DO1');
      return 'if (' + condition + ') {\n' + branch1 + '} else {\n' + branch2 + '}\n';
    };

    Blockly.JavaScript['controls_wait'] = function(block) {
      const duration = Blockly.JavaScript.valueToCode(block, 'DURATION', Blockly.JavaScript.ORDER_ATOMIC) || '1';
      return 'wait(' + duration + ');\n';
    };

    Blockly.JavaScript['sensing_touchingobject'] = function(block) {
      const object = block.getFieldValue('OBJECT');
      return ['touchingObject("' + object + '")', Blockly.JavaScript.ORDER_ATOMIC];
    };

    Blockly.JavaScript['sensing_keypressed'] = function(block) {
      const key = block.getFieldValue('KEY');
      return ['keyPressed("' + key + '")', Blockly.JavaScript.ORDER_ATOMIC];
    };

    Blockly.JavaScript['sensing_mousedown'] = function(block) {
      return ['mouseDown()', Blockly.JavaScript.ORDER_ATOMIC];
    };

    Blockly.JavaScript['sensing_mousex'] = function(block) {
      return ['mouseX()', Blockly.JavaScript.ORDER_ATOMIC];
    };

    Blockly.JavaScript['sensing_mousey'] = function(block) {
      return ['mouseY()', Blockly.JavaScript.ORDER_ATOMIC];
    };

    // Inicialización de Blockly
    document.addEventListener('DOMContentLoaded', function() {
      const workspace = Blockly.inject('blocklyDiv', {
        toolbox: document.getElementById('toolbox'),
        trashcan: true,
        scrollbars: true,
        zoom: {
          controls: true,
          wheel: true,
          startScale: 0.9,
          maxScale: 3,
          minScale: 0.3
        },
        move: {
          scrollbars: true,
          drag: true,
          wheel: true
        },
        theme: Blockly.Themes.Classic
      });
      
      // Variables globales para el estado de la aplicación
      let sprites = [];
      let currentSprite = null;
      let running = false;
      let executionQueue = [];
      let eventListeners = {
        flagClicked: [],
        keyPressed: {},
        spriteClicked: {},
        backdropSwitched: {}
      };
      
      // Función para agregar un nuevo sprite
      function addSprite(name = null) {
        const spriteId = 'sprite' + (sprites.length + 1);
        const spriteName = name || 'Sprite ' + (sprites.length + 1);
        const spriteColor = getRandomColor();
        
        const sprite = {
          id: spriteId,
          name: spriteName,
          x: 0,
          y: 0,
          size: 40,
          rotation: 0,
          color: spriteColor,
          visible: true,
          element: null
        };
        
        sprites.push(sprite);
        
        // Si es el primer sprite, lo seleccionamos
        if (sprites.length === 1) {
          selectSprite(sprite);
        }
        
        renderSpriteList();
        renderSpriteOnStage(sprite);
        
        return sprite;
      }
      
      // Función para seleccionar un sprite
      function selectSprite(sprite) {
        if (currentSprite) {
          const prevElement = document.querySelector(`.sprite-item[data-sprite="${currentSprite.id}"]`);
          if (prevElement) prevElement.classList.remove('active');
        }
        
        currentSprite = sprite;
        
        const element = document.querySelector(`.sprite-item[data-sprite="${sprite.id}"]`);
        if (element) element.classList.add('active');
        
        updatePropertiesPanel();
      }
      
      // Función para renderizar la lista de sprites
      function renderSpriteList() {
        const spritesList = document.getElementById('sprites-list');
        spritesList.innerHTML = '';
        
        sprites.forEach(sprite => {
          const spriteElement = document.createElement('div');
          spriteElement.className = `sprite-item ${sprite === currentSprite ? 'active' : ''}`;
          spriteElement.setAttribute('data-sprite', sprite.id);
          
          spriteElement.innerHTML = `
            <div class="sprite-preview" style="background-color: ${sprite.color}">
              <i class="fas fa-robot"></i>
            </div>
            <div class="sprite-info">
              <div class="sprite-name">${sprite.name}</div>
              <small>(${Math.round(sprite.x)}, ${Math.round(sprite.y)})</small>
            </div>
            <div class="sprite-actions">
              <button class="sprite-btn" data-action="edit"><i class="fas fa-edit"></i></button>
              <button class="sprite-btn" data-action="delete"><i class="fas fa-trash"></i></button>
            </div>
          `;
          
          spriteElement.addEventListener('click', () => selectSprite(sprite));
          
          // Manejar acciones de los botones
          const editBtn = spriteElement.querySelector('[data-action="edit"]');
          const deleteBtn = spriteElement.querySelector('[data-action="delete"]');
          
          editBtn.addEventListener('click', (e) => {
            e.stopPropagation();
            editSprite(sprite);
          });
          
          deleteBtn.addEventListener('click', (e) => {
            e.stopPropagation();
            deleteSprite(sprite);
          });
          
          spritesList.appendChild(spriteElement);
        });
      }
      
      // Función para renderizar un sprite en el escenario
      function renderSpriteOnStage(sprite) {
        const stage = document.getElementById('stage');
        
        if (sprite.element) {
          sprite.element.remove();
        }
        
        const spriteElement = document.createElement('div');
        spriteElement.className = 'sprite-display';
        spriteElement.setAttribute('data-sprite', sprite.id);
        spriteElement.style.backgroundColor = sprite.color;
        spriteElement.style.left = `${sprite.x + 140}px`;
        spriteElement.style.top = `${125 - sprite.y}px`;
        spriteElement.style.width = `${sprite.size}px`;
        spriteElement.style.height = `${sprite.size}px`;
        spriteElement.style.transform = `rotate(${sprite.rotation}deg)`;
        spriteElement.style.opacity = sprite.visible ? '1' : '0';
        
        spriteElement.innerHTML = `<i class="fas fa-robot"></i>`;
        
        // Hacer el sprite arrastrable
        interact(spriteElement).draggable({
          inertia: false,
          modifiers: [
            interact.modifiers.restrictRect({
              restriction: 'parent',
              endOnly: true
            })
          ],
          listeners: {
            move: function(event) {
              sprite.x += event.dx;
              sprite.y -= event.dy;
              updateSpritePosition(sprite);
            }
          }
        });
        
        // Manejar clic en el sprite
        spriteElement.addEventListener('click', () => {
          selectSprite(sprite);
          triggerEvent('spriteClicked', sprite.id);
        });
        
        stage.appendChild(spriteElement);
        sprite.element = spriteElement;
      }
      
      // Función para actualizar la posición visual de un sprite
      function updateSpritePosition(sprite) {
        if (sprite.element) {
          sprite.element.style.left = `${sprite.x + 140}px`;
          sprite.element.style.top = `${125 - sprite.y}px`;
          sprite.element.style.transform = `rotate(${sprite.rotation}deg)`;
        }
        
        // Actualizar la lista de sprites si es necesario
        const spriteItem = document.querySelector(`.sprite-item[data-sprite="${sprite.id}"] small`);
        if (spriteItem) {
          spriteItem.textContent = `(${Math.round(sprite.x)}, ${Math.round(sprite.y)})`;
        }
      }
      
      // Función para actualizar el panel de propiedades
      function updatePropertiesPanel() {
        if (!currentSprite) return;
        
        document.getElementById('sprite-name-input').value = currentSprite.name;
        document.getElementById('sprite-x-input').value = currentSprite.x;
        document.getElementById('sprite-y-input').value = currentSprite.y;
        document.getElementById('sprite-size-input').value = currentSprite.size;
        document.getElementById('sprite-rotation-input').value = currentSprite.rotation;
        
        document.getElementById('sprite-x-value').textContent = Math.round(currentSprite.x);
        document.getElementById('sprite-y-value').textContent = Math.round(currentSprite.y);
        document.getElementById('sprite-size-value').textContent = currentSprite.size;
        document.getElementById('sprite-rotation-value').textContent = currentSprite.rotation;
      }
      
      // Función para editar un sprite
      function editSprite(sprite) {
        const newName = prompt('Nuevo nombre para el sprite:', sprite.name);
        if (newName && newName.trim() !== '') {
          sprite.name = newName.trim();
          renderSpriteList();
        }
      }
      
      // Función para eliminar un sprite
      function deleteSprite(sprite) {
        if (confirm(`¿Estás seguro de que quieres eliminar "${sprite.name}"?`)) {
          const index = sprites.indexOf(sprite);
          if (index > -1) {
            sprites.splice(index, 1);
          }
          
          if (sprite.element) {
            sprite.element.remove();
          }
          
          if (currentSprite === sprite) {
            currentSprite = sprites.length > 0 ? sprites[0] : null;
          }
          
          renderSpriteList();
          
          if (currentSprite) {
            selectSprite(currentSprite);
          } else {
            // No hay sprites, limpiar panel de propiedades
            document.getElementById('sprite-name-input').value = '';
          }
        }
      }
      
      // Función para obtener un color aleatorio
      function getRandomColor() {
        const colors = [
          '#FF5252', '#FF4081', '#E040FB', '#7C4DFF', '#536DFE', 
          '#448AFF', '#40C4FF', '#18FFFF', '#64FFDA', '#69F0AE', 
          '#B2FF59', '#EEFF41', '#FFFF00', '#FFD740', '#FFAB40', 
          '#FF6E40', '#6A5ACD', '#20B2AA', '#FF7F50', '#9370DB'
        ];
        return colors[Math.floor(Math.random() * colors.length)];
      }
      
      // Función para ejecutar el código
      function executeCode() {
        if (running) return;
        
        running = true;
        addConsoleMessage('Ejecutando programa...', 'success');
        
        try {
          // Limpiar event listeners anteriores
          eventListeners = {
            flagClicked: [],
            keyPressed: {},
            spriteClicked: {},
            backdropSwitched: {}
          };
          
          // Generar código para todos los sprites
          const code = Blockly.JavaScript.workspaceToCode(workspace);
          
          // Definir funciones globales para la ejecución
          const globalFunctions = {
            moveSteps: function(steps) {
              if (!currentSprite) return;
              const radians = currentSprite.rotation * Math.PI / 180;
              currentSprite.x += steps * Math.sin(radians);
              currentSprite.y += steps * Math.cos(radians);
              updateSpritePosition(currentSprite);
            },
            turnRight: function(degrees) {
              if (!currentSprite) return;
              currentSprite.rotation = (currentSprite.rotation + Number(degrees)) % 360;
              updateSpritePosition(currentSprite);
            },
            turnLeft: function(degrees) {
              if (!currentSprite) return;
              currentSprite.rotation = (currentSprite.rotation - Number(degrees)) % 360;
              updateSpritePosition(currentSprite);
            },
            goToXY: function(x, y) {
              if (!currentSprite) return;
              currentSprite.x = Number(x);
              currentSprite.y = Number(y);
              updateSpritePosition(currentSprite);
            },
            changeX: function(dx) {
              if (!currentSprite) return;
              currentSprite.x += Number(dx);
              updateSpritePosition(currentSprite);
            },
            changeY: function(dy) {
              if (!currentSprite) return;
              currentSprite.y += Number(dy);
              updateSpritePosition(currentSprite);
            },
            setRotation: function(degrees) {
              if (!currentSprite) return;
              currentSprite.rotation = Number(degrees) % 360;
              updateSpritePosition(currentSprite);
            },
            say: function(text) {
              addConsoleMessage(text.toString(), 'info');
            },
            changeColor: function(color) {
              if (!currentSprite) return;
              currentSprite.color = color;
              if (currentSprite.element) {
                currentSprite.element.style.backgroundColor = color;
              }
            },
            setSize: function(size) {
              if (!currentSprite) return;
              currentSprite.size = Math.min(150, Math.max(20, Number(size)));
              if (currentSprite.element) {
                currentSprite.element.style.width = `${currentSprite.size}px`;
                currentSprite.element.style.height = `${currentSprite.size}px`;
              }
            },
            showSprite: function() {
              if (!currentSprite) return;
              currentSprite.visible = true;
              if (currentSprite.element) {
                currentSprite.element.style.opacity = '1';
              }
            },
            hideSprite: function() {
              if (!currentSprite) return;
              currentSprite.visible = false;
              if (currentSprite.element) {
                currentSprite.element.style.opacity = '0';
              }
            },
            wait: function(seconds) {
              return new Promise(resolve => {
                setTimeout(resolve, seconds * 1000);
              });
            },
            touchingObject: function(object) {
              // Implementación simplificada de detección de colisiones
              return false;
            },
            keyPressed: function(key) {
              // Implementación simplificada de detección de teclas
              return false;
            },
            mouseDown: function() {
              // Implementación simplificada de detección de ratón
              return false;
            },
            mouseX: function() {
              // Implementación simplificada de posición del ratón
              return 0;
            },
            mouseY: function() {
              // Implementación simplificada de posición del ratón
              return 0;
            },
            whenFlagClicked: function(callback) {
              eventListeners.flagClicked.push(callback);
            },
            whenKeyPressed: function(key, callback) {
              if (!eventListeners.keyPressed[key]) {
                eventListeners.keyPressed[key] = [];
              }
              eventListeners.keyPressed[key].push(callback);
            },
            whenThisSpriteClicked: function(spriteId, callback) {
              if (!eventListeners.spriteClicked[spriteId]) {
                eventListeners.spriteClicked[spriteId] = [];
              }
              eventListeners.spriteClicked[spriteId].push(callback);
            },
            whenBackdropSwitchesTo: function(backdrop, callback) {
              if (!eventListeners.backdropSwitched[backdrop]) {
                eventListeners.backdropSwitched[backdrop] = [];
              }
              eventListeners.backdropSwitched[backdrop].push(callback);
            }
          };
          
          // Evaluar el código generado
          eval(code);
          
          // Ejecutar los listeners de la bandera verde
          eventListeners.flagClicked.forEach(callback => {
            try {
              callback();
            } catch (e) {
              addConsoleMessage(`Error al ejecutar: ${e.message}`, 'error');
              console.error(e);
            }
          });
          
        } catch (e) {
          addConsoleMessage(`Error al ejecutar: ${e.message}`, 'error');
          console.error(e);
        } finally {
          running = false;
        }
      }
      
      // Función para detener la ejecución
      function stopExecution() {
        // En una implementación real, necesitaríamos una forma de detener los bucles
        running = false;
        addConsoleMessage('Ejecución detenida', 'warning');
      }
      
      // Función para reiniciar el escenario
      function resetStage() {
        sprites.forEach(sprite => {
          sprite.x = 0;
          sprite.y = 0;
          sprite.rotation = 0;
          sprite.visible = true;
          updateSpritePosition(sprite);
        });
        
        if (sprites.length > 0) {
          selectSprite(sprites[0]);
        }
        
        addConsoleMessage('Escenario reiniciado', 'success');
      }
      
      // Función para limpiar la consola
      function clearConsole() {
        document.getElementById('output-console').innerHTML = `
          <div class="console-message console-success">Consola limpiada</div>
          <div class="console-message">Listo para programar...</div>
        `;
      }
      
      // Función para agregar un mensaje a la consola
      function addConsoleMessage(message, type = 'info') {
        const consoleElement = document.getElementById('output-console');
        const messageElement = document.createElement('div');
        messageElement.className = `console-message console-${type}`;
        messageElement.textContent = message;
        consoleElement.appendChild(messageElement);
        consoleElement.scrollTop = consoleElement.scrollHeight;
      }
      
      // Función para disparar eventos
      function triggerEvent(type, data) {
        switch (type) {
          case 'spriteClicked':
            if (eventListeners.spriteClicked[data]) {
              eventListeners.spriteClicked[data].forEach(callback => callback());
            }
            break;
          // Implementar otros tipos de eventos según sea necesario
        }
      }
      
      // Manejar cambios en las propiedades del sprite
      document.getElementById('sprite-name-input').addEventListener('change', function() {
        if (currentSprite) {
          currentSprite.name = this.value;
          renderSpriteList();
        }
      });
      
      document.getElementById('sprite-x-input').addEventListener('input', function() {
        if (currentSprite) {
          currentSprite.x = Number(this.value);
          document.getElementById('sprite-x-value').textContent = Math.round(currentSprite.x);
          updateSpritePosition(currentSprite);
        }
      });
      
      document.getElementById('sprite-y-input').addEventListener('input', function() {
        if (currentSprite) {
          currentSprite.y = Number(this.value);
          document.getElementById('sprite-y-value').textContent = Math.round(currentSprite.y);
          updateSpritePosition(currentSprite);
        }
      });
      
      document.getElementById('sprite-size-input').addEventListener('input', function() {
        if (currentSprite) {
          currentSprite.size = Number(this.value);
          document.getElementById('sprite-size-value').textContent = currentSprite.size;
          if (currentSprite.element) {
            currentSprite.element.style.width = `${currentSprite.size}px`;
            currentSprite.element.style.height = `${currentSprite.size}px`;
          }
        }
      });
      
      document.getElementById('sprite-rotation-input').addEventListener('input', function() {
        if (currentSprite) {
          currentSprite.rotation = Number(this.value);
          document.getElementById('sprite-rotation-value').textContent = currentSprite.rotation;
          if (currentSprite.element) {
            currentSprite.element.style.transform = `rotate(${currentSprite.rotation}deg)`;
          }
        }
      });
      
      // Manejar pestañas
      document.querySelectorAll('.tab').forEach(tab => {
        tab.addEventListener('click', function() {
          const tabId = this.getAttribute('data-tab');
          
          // Desactivar todas las pestañas
          document.querySelectorAll('.tab').forEach(t => t.classList.remove('active'));
          document.querySelectorAll('.tab-content').forEach(c => c.classList.remove('active'));
          
          // Activar la pestaña seleccionada
          this.classList.add('active');
          document.getElementById(`${tabId}-tab`).classList.add('active');
        });
      });
      
      // Manejar botones de control
      document.getElementById('run-button').addEventListener('click', executeCode);
      document.getElementById('stop-button').addEventListener('click', stopExecution);
      document.getElementById('reset-button').addEventListener('click', resetStage);
      document.getElementById('clear-btn').addEventListener('click', clearConsole);
      document.getElementById('add-sprite-btn').addEventListener('click', () => addSprite());
      
      // Manejar teclas de acceso rápido
      document.addEventListener('keydown', function(e) {
        if (e.ctrlKey && e.key === 'Enter') {
          executeCode();
        }
      });
      
      // Inicializar con un sprite por defecto
      addSprite('Personaje');
    });
  </script>
</body>
</html>