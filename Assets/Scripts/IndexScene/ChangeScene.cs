using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace IndexScene
{
    public class ChangeScene : MonoBehaviour
    {
        [SerializeField] Image darkEffect;

        void Update()
        {
            if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
            {

            }
        }

        public void onClick()
        {
            string sceneName = "SelectStageScene";
            StartCoroutine(fadeOut(sceneName));
        }

        IEnumerator fadeIn(string sceneName)
        {
            float alpha = 1, speed = 2f, time;

            darkEffect.gameObject.SetActive(true);
            setAlpha(darkEffect, alpha);
            while (0 < alpha)
            {
                time = Time.deltaTime;
                alpha -= speed * time;
                setAlpha(darkEffect, alpha);
                yield return new WaitForSeconds(time);
            }
            alpha = 0;
            setAlpha(darkEffect, alpha);

            darkEffect.gameObject.SetActive(false);
            SceneManager.LoadScene(sceneName);
        }

        IEnumerator fadeOut(string sceneName)
        {
            float alpha = 0, speed = 2f, time;

            darkEffect.gameObject.SetActive(true);
            setAlpha(darkEffect, alpha);
            while (alpha < 1)
            {
                time = Time.deltaTime;
                alpha += speed * time;
                setAlpha(darkEffect, alpha);
                yield return new WaitForSeconds(time);
            }
            alpha = 1;
            setAlpha(darkEffect, alpha);

            yield return new WaitForSeconds(2f);
            darkEffect.gameObject.SetActive(false);
            SceneManager.LoadScene(sceneName);
        }

        void setAlpha(Image image, float alpha)
        {
            Color c;
            c = image.color;
            c.a = alpha;
            image.color = c;
        }
    }
}