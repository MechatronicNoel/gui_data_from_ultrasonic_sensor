long distancia;
long tiempo;
void setup(){
  Serial.begin(115200);
  pinMode(9, OUTPUT); 
  pinMode(8, INPUT); 
}

void loop(){
  digitalWrite(9,LOW); 
  delayMicroseconds(5);
  digitalWrite(9, HIGH); 
  delayMicroseconds(10);
  tiempo=pulseIn(8, HIGH); 

  
  distancia= int(0.017*tiempo); /*fórmula para calcular la distancia obteniendo un valor entero*/

  if (distancia >= 30){
    distancia=30;
  }
  
  
  Serial.println(distancia);
  delay(100);
}
  
