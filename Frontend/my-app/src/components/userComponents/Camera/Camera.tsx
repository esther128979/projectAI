import React, { useState, useRef, useEffect } from 'react';

interface CameraProps {
  onCapture: (imageData: string) => void;
}

const Camera: React.FC<CameraProps> = ({ onCapture }) => {
  const [hasPermission, setHasPermission] = useState<boolean | null>(null);
  const [capturedImage, setCapturedImage] = useState<string | null>(null);
  const videoRef = useRef<HTMLVideoElement | null>(null);
  const canvasRef = useRef<HTMLCanvasElement | null>(null);

  useEffect(() => {
    // בקשת גישה למצלמה ברגע שהקומפוננטה עולה
    const startCamera = async () => {
      try {
        const stream = await navigator.mediaDevices.getUserMedia({ video: true });
        if (videoRef.current) {
          videoRef.current.srcObject = stream;
        }
        setHasPermission(true);
      } catch (err) {
        console.error('Camera permission denied', err);
        setHasPermission(false);
      }
    };

    startCamera();
  }, []);

  const captureImage = () => {
    if (!canvasRef.current || !videoRef.current) return;

    const canvas = canvasRef.current;
    const context = canvas.getContext('2d');
    if (!context) return;

    // ציור מהווידאו לתוך הקנבס
    context.drawImage(videoRef.current, 0, 0, canvas.width, canvas.height);
    const imageData = canvas.toDataURL('image/jpeg');
    setCapturedImage(imageData);         // שמירת התמונה בתצוגה
    onCapture(imageData);                // שליחה לפונקציה חיצונית אם צריך
  };

  return (
    <div>
      {hasPermission === null && <p>טוען מצלמה...</p>}
      {hasPermission === false && <p>גישה למצלמה נדחתה.</p>}
      {hasPermission && (
        <div>
          <video ref={videoRef} autoPlay width="320" height="240" />
          <br />
          <button onClick={captureImage}>📸 צלם תמונה</button>
          <canvas
            ref={canvasRef}
            width="320"
            height="240"
            style={{ display: 'none' }}
          />
          {capturedImage && (
            <div>
              <h4>תמונה שצולמה:</h4>
              <img src={capturedImage} alt="Captured" style={{ border: '1px solid #ccc' }} />
            </div>
          )}
        </div>
      )}
    </div>
  );
};

export default Camera;
