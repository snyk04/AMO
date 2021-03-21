package com.example.lab_1


import com.google.android.material.textfield.TextInputLayout
import androidx.appcompat.app.AppCompatActivity
import androidx.appcompat.app.AlertDialog
import android.widget.TextView
import android.content.Intent
import android.widget.Button
import android.os.Bundle
import kotlin.math.cos
import kotlin.math.pow
import kotlin.math.sin


class Activity1 : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_1)

        configureCalculateButton()
        configurePageButtons()
    }

    private fun configureCalculateButton() {
        val aInput: TextInputLayout = findViewById(R.id.a)
        val bInput: TextInputLayout = findViewById(R.id.b)
        val calculateButton: Button = findViewById(R.id.calculateButton)
        val resultText: TextView = findViewById(R.id.resultText)

        calculateButton.setOnClickListener {
            val alertDialog : AlertDialog = AlertDialog.Builder(this).create()
            alertDialog.setTitle("Помилка")

            val aValue: Float
            val bValue: Float
            try{
                aValue = aInput.editText?.text.toString().toFloat()
                bValue = bInput.editText?.text.toString().toFloat()
            } catch(exception: Exception) {
                alertDialog.setMessage("Некоректно введені значення а та b")
                return@setOnClickListener
            }

            if (aValue + bValue == 0f) {
                alertDialog.setMessage("a + b = 0\n" +
                        "Виникає ділення на ноль\n" +
                        "Потрібно змінити аргумент a або b"
                )
                alertDialog.show()
                return@setOnClickListener
            } else {
                val argument: Float = (aValue + bValue) / ((aValue + bValue).pow(2))
                val resultValue: Float = sin(argument) + cos(argument)
                resultText.text = ("Y1 = $resultValue").toString()
            }
        }
    }
    private fun configurePageButtons() {
        val nextPageButton: Button = findViewById(R.id.nextPageButton1)
        val infoButton: Button = findViewById(R.id.infoButton1)

        nextPageButton.setOnClickListener {
            val myIntent = Intent(this@Activity1, Activity2::class.java)
            this@Activity1.startActivity(myIntent)
        }
        infoButton.setOnClickListener {
            val myIntent = Intent(this@Activity1, InfoPage::class.java)
            this@Activity1.startActivity(myIntent)
        }
    }
}
