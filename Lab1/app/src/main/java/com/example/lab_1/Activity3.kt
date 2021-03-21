package com.example.lab_1


import com.google.android.material.textfield.TextInputLayout
import androidx.appcompat.app.AppCompatActivity
import androidx.appcompat.app.AlertDialog
import android.widget.TextView
import android.content.Intent
import android.widget.Button
import android.os.Bundle
import java.lang.Exception


class Activity3 : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_3)

        configureCalculateButton()
        configurePageButtons()
    }

    private fun configureCalculateButton() {
        val nInput: TextInputLayout = findViewById(R.id.n)
        val arrayAInput: TextInputLayout = findViewById(R.id.arrayA)
        val arrayBInput: TextInputLayout = findViewById(R.id.arrayB)
        val calculateButton: Button = findViewById(R.id.calculateButton3)
        val resultText: TextView = findViewById(R.id.resultText3)

        calculateButton.setOnClickListener {
            val alertDialog : AlertDialog = AlertDialog.Builder(this).create()
            alertDialog.setTitle("Помилка")

            val nValue: Int
            try {
                nValue = nInput.editText?.text.toString().toInt()
            } catch (exception : Exception) {
                alertDialog.setMessage("n введено некоректно, або воно не є цілим числом")
                alertDialog.show()
                return@setOnClickListener
            }
            if (nValue < 1) {
                alertDialog.setMessage("n меньше за 1, що є неможливим в даній формулі")
                alertDialog.show()
                return@setOnClickListener
            }

            val arrayAValueString: String
            val arrayBValueString: String
            val arrayAValue: List<Int>
            val arrayBValue: List<Int>

            try {
                arrayAValueString = arrayAInput.editText?.text.toString()
                arrayBValueString = arrayBInput.editText?.text.toString()
                arrayAValue = arrayToInt(arrayAValueString.split(" "))
                arrayBValue = arrayToInt(arrayBValueString.split(" "))
            } catch(error: Exception) {
                alertDialog.setMessage("Масив заданий невірно")
                alertDialog.show()
                return@setOnClickListener
            }
            if ((arrayAValue.size != nValue) and (arrayBValue.size != nValue)) {
                alertDialog.setMessage("Розмірність одного або двох масивів не дорвнює n")
                alertDialog.show()
                return@setOnClickListener
            }
            if (!anythingExceptZero(arrayAValue) and !anythingExceptZero(arrayBValue)) {
                alertDialog.setMessage("Усі елементи обох масивів дорівнюють нулю, " +
                        "отже виникає ділення на нуль")
                alertDialog.show()
                return@setOnClickListener
            }

            val nominator: Long = factorial(nValue) * nValue
            var denominator: Double = 0.0
            for (i in 0.until(nValue)) { denominator += arrayAValue[i] + arrayBValue[i] }
            val resultValue: Double = nominator / denominator

            resultText.text = ("f = $resultValue").toString()
        }
    }
    private fun configurePageButtons() {
        val previousPageButton: Button = findViewById(R.id.previousPageButton3)
        val infoButton: Button = findViewById(R.id.infoButton3)

        previousPageButton.setOnClickListener {
            val myIntent = Intent(this@Activity3, Activity2::class.java)
            this@Activity3.startActivity(myIntent)
        }
        infoButton.setOnClickListener {
            val myIntent = Intent(this@Activity3, InfoPage::class.java)
            this@Activity3.startActivity(myIntent)
        }
    }

    private fun arrayToInt(stringArray: List<String>) : List<Int> {
        val intArray = mutableListOf<Int>()
        stringArray.forEach { intArray.add(it.toInt()) }
        return intArray
    }
    private fun factorial(number: Int) : Long {
        var factorial: Long = 1
        for (i in 1..number) { factorial *= i }
        return factorial
    }
    private fun anythingExceptZero(array : List<Int>) : Boolean {
        array.forEach {
            if (it != 0) return true
        }
        return false
    }
}
