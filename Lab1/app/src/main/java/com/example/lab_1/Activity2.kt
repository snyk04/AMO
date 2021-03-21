package com.example.lab_1


import com.google.android.material.textfield.TextInputLayout
import androidx.appcompat.app.AppCompatActivity
import androidx.appcompat.app.AlertDialog
import android.widget.TextView
import android.content.Intent
import android.widget.Button
import android.os.Bundle
import kotlin.math.sqrt
import kotlin.math.pow


class Activity2 : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_2)

        configureCalculateButton()
        configurePageButtons()
    }

    private fun configureCalculateButton() {
        val rInput: TextInputLayout = findViewById(R.id.r)
        val gInput: TextInputLayout = findViewById(R.id.g)
        val xInput: TextInputLayout = findViewById(R.id.x)
        val calculateButton: Button = findViewById(R.id.calculateButton2)
        val resultText: TextView = findViewById(R.id.resultText2)
        val algorithmTypeText: TextView = findViewById(R.id.algorithmTypeText)

        calculateButton.setOnClickListener {
            val alertDialog : AlertDialog = AlertDialog.Builder(this).create()
            alertDialog.setTitle("Помилка")

            val rValue: Float
            val gValue: Float
            val xValue: Float
            try {
                rValue = rInput.editText?.text.toString().toFloat()
                gValue = gInput.editText?.text.toString().toFloat()
                xValue = xInput.editText?.text.toString().toFloat()
            } catch(exception: Exception) {
                alertDialog.setMessage("Некоректно введені значення а та b")
                return@setOnClickListener
            }

            var resultValue: Float = 0f
            if (rValue * gValue != 0f) {
                val nominator: Float = xValue + 24 * xValue.pow(2)
                val denominator: Float = rValue * gValue
                resultValue = nominator / denominator
                algorithmTypeText.text = "r * g != 0"
            }
            else {
                resultValue = sqrt(rValue + xValue) + gValue * xValue
                algorithmTypeText.text = "r * g == 0"
            }

            resultText.text = ("y = $resultValue").toString()
        }
    }
    private fun configurePageButtons() {
        val previousPageButton: Button = findViewById(R.id.previousPageButton2)
        val nextPageButton: Button = findViewById(R.id.nextPageButton2)
        val infoButton: Button = findViewById(R.id.infoButton2)

        previousPageButton.setOnClickListener {
            val myIntent = Intent(this@Activity2, Activity1::class.java)
            this@Activity2.startActivity(myIntent)
        }
        nextPageButton.setOnClickListener {
            val myIntent = Intent(this@Activity2, Activity3::class.java)
            this@Activity2.startActivity(myIntent)
        }
        infoButton.setOnClickListener {
            val myIntent = Intent(this@Activity2, InfoPage::class.java)
            this@Activity2.startActivity(myIntent)
        }
    }
}
