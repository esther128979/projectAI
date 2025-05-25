import React, { useState, useEffect } from "react";

const faqData = [
  {
    question: "מי יכול להשתמש באתר?",
    answer: "האתר פתוח למשתמשים רשומים בלבד. כל צפייה דורשת הרשמה מוקדמת ואישור תנאי שימוש.",
  },
  {
    question: "האם ניתן לצפות חופשי בתכנים?",
    answer: "לא. יש להזמין סרטים לפי הצורך. תהליך ההזמנה כולל בחירת סרט, כמות צפיות וכמות צופים – והמחיר משתנה בהתאם.",
  },
  {
    question: "איך מקבלים את הסרט?",
    answer: "לאחר השלמת ההזמנה, קישור אישי לצפייה נשלח למייל שלכם. הקישור פעיל לפי התנאים שהוגדרו (מספר צפיות ומספר צופים).",
  },
  {
    question: "האם כל תוכן נבדק?",
    answer: "כן. כל התכנים באתר עוברים סינון קפדני לפני פרסום, במטרה לשמור על סביבה נקייה ומכובדת.",
  },
  {
    question: "איך יוצרים קשר?",
    answer: (
      <span>
        ניתן ליצור קשר דרך{" "}
        <a
          
        >
          הצ'אט באתר
        </a>{" "}
        או במייל:{" "}
        <a
          href="mailto:dosflix.service@gmail.com"
          style={{ color: "#007acc", textDecoration: "underline" }}
        >
          dosflix.service@gmail.com
        </a>
      </span>
    ),
  },
];

const RegistrationIntro = () => {
  const [visible, setVisible] = useState(false);

  useEffect(() => {
    const timeout = setTimeout(() => setVisible(true), 300);
    return () => clearTimeout(timeout);
  }, []);

  return (
    <div
      style={{
        opacity: visible ? 1 : 0,
        transition: "opacity 1s ease-in-out",
        backgroundColor: "#e0f7fa",
        padding: "1.5em 2em",
        borderRadius: 12,
        fontFamily: "'Noto Sans Hebrew', sans-serif",
        direction: "rtl",
        color: "#006064",
        marginBottom: "2em",
        boxShadow: "0 2px 8px rgba(0,0,0,0.1)",
      }}
    >
      <h2 style={{ marginBottom: "0.5em" }}>הצטרפו למהפכת הצפייה החכמה ב-DosFlix!</h2>
      <p>
        ב-DosFlix, תהליך ההרשמה הוא לא סתם רישום – זו התחלה של חוויית צפייה מותאמת אישית עם טכנולוגיות הבינה המלאכותית המתקדמות ביותר.
        התחברו בקלות ובבטחה באמצעות צילום פנים מתקדם, והתחילו ליהנות מתוכן איכותי שמותאם בדיוק לכם.
      </p>
      <ul style={{ paddingRight: "1.2em" }}>
        <li>התאמה אישית חכמה שמשתפרת עם הזמן</li>
        <li>ממשק משתמש ידידותי ונגיש</li>
        <li>הגנה מלאה על הפרטיות שלכם</li>
        <li>קישורי צפייה אישיים ומותאמים לכם במייל</li>
      </ul>
    </div>
  );
};

const About = () => {
  const [openIndex, setOpenIndex] = useState(null);

  const toggleFAQ = (index: any) => {
    setOpenIndex(openIndex === index ? null : index);
  };

  return (
    <div
      style={{
        direction: "rtl",
        textAlign: "right",
        fontFamily: "'Noto Sans Hebrew', sans-serif",
        lineHeight: 1.7,
        padding: "1.5em 2em",
        backgroundColor: "#f8fafc",
        borderRadius: 12,
        maxWidth: 800,
        margin: "8vh auto 2em",
        boxShadow: "0 0 10px rgba(0,0,0,0.1)",
        color: "#3e3e3e",
      }}
    >
      <RegistrationIntro />

      <h2 style={{ fontSize: "1.6em", marginBottom: "1em" }}>
        אתר "DosFlix" – צפייה מותאמת, תוכן איכותי
      </h2>

      <p>
        DosFlix הוא אתר צפייה סגור למשתמשים רשומים, שמציע חוויית תוכן אישית, מסוננת ונעימה. האתר הוקם על ידי הזוג רפאל ונעמי קליפשטיין מירושלים, מתוך רצון להעניק תוכן נקי, מותאם ומשמעותי למשפחות, בני נוער ואנשים שמחפשים איכות גם בעולם הדיגיטלי.
      </p>

      <p>
        כל משתמש מצטרף לתהליך הרשמה הכולל צילום פנים – והמערכת מזהה את המשתמש ומציעה לו סרטים מתאימים אישית. לאחר ההזמנה מתקבל מייל אישי עם קישור לצפייה, שמוגבל לפי מספר הצפיות וכמות האנשים שהוגדרה. התמחור מתחשב בכל אלו.
      </p>

      <h3 style={{ marginTop: "1.5em", marginBottom: "0.7em" }}>
        עקרונות הפעולה של DosFlix:
      </h3>
      <ul style={{ paddingRight: "1.2em" }}>
        <li><strong>התאמה אישית:</strong> חוויית צפייה לפי גיל, אופי וצורך.</li>
        <li><strong>ללא פרסומות:</strong> סביבת צפייה שקטה, נעימה ונקייה.</li>
        <li><strong>תוכן מסונן:</strong> כל סרט נבדק ונבחר בקפידה.</li>
        <li><strong>שירות אישי:</strong> זמינות מלאה דרך מייל או צ'אט.</li>
      </ul>

      <h3 style={{ marginTop: "2em", marginBottom: "0.7em" }}>שאלות נפוצות</h3>
      <div>
        {faqData.map((faq, index) => (
          <div key={index} style={{ marginBottom: "1em" }}>
            <div
              onClick={() => toggleFAQ(index)}
              style={{
                cursor: "pointer",
                fontWeight: "bold",
                background: "#e2e8f0",
                padding: "0.6em 1em",
                borderRadius: 8,
              }}
            >
              {faq.question}
            </div>
            {openIndex === index && (
              <div
                style={{
                  background: "#f1f5f9",
                  padding: "0.8em 1em",
                  borderRadius: "0 0 8px 8px",
                  marginTop: "-0.2em",
                }}
              >
                {faq.answer}
              </div>
            )}
          </div>
        ))}
      </div>
    </div>
  );
};

export default About;
